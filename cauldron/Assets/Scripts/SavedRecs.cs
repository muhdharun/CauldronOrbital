using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SavedRecs : MonoBehaviour {

    DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;

    public static string CurrentUser;
    public int index = 0;

    public static Text r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16, r17, r18, r19, r20, r21, r22, r23, r24,
        r25, r26, r27, r28, r29, r30;
    public static GameObject b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13, b14, b15, b16, b17, b18, b19, b20, b21, b22, b23, b24,
        b25, b26, b27, b28, b29, b30;

    public List<Text> Recipes = new List<Text>(){r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16, r17, r18, r19, r20, r21, r22, r23, r24,
    r25, r26, r27, r28, r29, r30 };

    public List<GameObject> Buttons = new List<GameObject>() {b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13, b14, b15, b16, b17, b18, b19, b20, b21, b22, b23, b24,
        b25, b26, b27, b28, b29, b30};

    public static string store;
    

    // Use this for initialization
    void Start () {
        CurrentUser = UIAuth.editedEmail;              
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                FirebaseApp app = FirebaseApp.DefaultInstance;
                app.SetEditorDatabaseUrl("https://cauldron-493c1.firebaseio.com/");
                if (app.Options.DatabaseUrl != null) app.SetEditorDatabaseUrl(app.Options.DatabaseUrl);
                

            }
            else
            {
                Debug.LogError(
                  "Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
        foreach (Text Rec in Recipes)
        {

            Rec.enabled = false;
        }
        foreach (GameObject button in Buttons)
        {
            button.SetActive(false);
        }
    }
    
    public void ShowSavedRecs()
    {
        
        FirebaseDatabase dbRef = FirebaseDatabase.DefaultInstance;
        dbRef.GetReference("Users").Child(CurrentUser).Child("Saved").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                
                DataSnapshot savedrecs = task.Result;
                Debug.Log(savedrecs.ChildrenCount);
                foreach (DataSnapshot rec in savedrecs.Children)
                {
                    Debug.Log("Processing...");
                    if (index > 29)
                    {
                        break;
                    }
                    if (index < 15)
                    {                                             
                        Debug.Log("standby...");                                              
                        Recipes[index].GetComponent<Text>().text = rec.Key;                       
                        Debug.Log(Recipes[index].GetComponent<Text>().text);
                        Button open = Buttons[index].GetComponent<Button>();
                        Debug.Log("Open activated...");
                        if ((string)rec.Child("Type").Value == "internet")
                        {
                            open.onClick.AddListener(() => { OpenPage((string)rec.Child("Steps").Value); });
                        }
                        else
                        {
                            store = (string)rec.Child("Steps").Value;
                            open.onClick.AddListener(() => { OpenNonIntPage(); });
                        }
                        Recipes[index].enabled = true;
                        Buttons[index].SetActive(true);
                        index++;
                    }
                    else if(index > 14 && index < 30)
                    {
                        Debug.Log("standby...");
                        Recipes[index].GetComponent<Text>().text = rec.Key;
                        Debug.Log(Recipes[index].GetComponent<Text>().text);
                        Button open = Buttons[index].GetComponent<Button>();
                        if ((string)rec.Child("Type").Value == "internet")
                        {
                            open.onClick.AddListener(() => { OpenPage((string)rec.Child("Steps").Value); });
                        }
                        else
                        {
                            store = (string)rec.Child("Steps").Value;
                            open.onClick.AddListener(() => { OpenNonIntPage(); });
                        }
                        Recipes[index].enabled = true;
                        Buttons[index].SetActive(true);
                        index++;
                    }
                    
                }
            }
        });

    }

    public void OpenNonIntPage()
    {
        SceneManager.LoadSceneAsync("SavedNonInt");
    }

    public void OpenPage(string url)
    {
        Application.OpenURL(url);
    }

    public void Back()
    {
        SceneManager.LoadSceneAsync("titlescreen"); 
    }
}

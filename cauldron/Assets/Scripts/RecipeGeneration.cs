using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using System.Collections;


public class RecipeGeneration : MonoBehaviour {

    //every time an acc is created, user's email would appear as a key in FBDB
    //Each user has 2 keys, saved and contributions

    //Algo to generate recs:
    //Compare size of useringredients and ingredient list of each rec in DB depending on type of meal
    // Loop through the data structure that is smaller and find matching ingredients
    //each rec would have a tmp total_score var
    // total_score = number of ingredients to 'catch up' (the lower the better) - votes
    //top 3 shown + show more option 


    public DatabaseReference REF;
    public static string UserName;

    public static string MealType; //from TypeOfMealPage script
    //int userIngs; //number of user's ingredients (from IngredientSelection)
    bool nothing = false;
    
    DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;

    Dictionary<string, int> Score = new Dictionary<string, int>();
    Dictionary<string, string[]> results = new Dictionary<string, string[]>();
    // index 0: Recipe_type,1: Ingredients 2: Steps/Website 3: Picture link  

    public static bool Guest = false;

    public GameObject show_button;
    public GameObject save1;
    public GameObject save2;
    public GameObject save3;

    public static string store;

    public Text status;
    //titles of top 3 recipes
    public Text t1;
    public Text t2;
    public Text t3;

    //ingredients of top 3 recips
    public Text i1;
    public Text i2;
    public Text i3;

    //content of top 3 recipes
    public Text r1;
    public Text r2;
    public Text r3;

    public RawImage pic1;
    public RawImage pic2;
    public RawImage pic3;

    public string url1;
    public string url2;
    public string url3; 

    //is it from the internet?
    bool int1 = false;
    bool int2 = false;
    bool int3 = false;

    public Text UsersSelection;

    // Use this for initialization
    void Start () {
        url1 = url2 = url3 = "nil";
        UserName = UIAuth.editedEmail;
        //pic1 = gameObject.GetComponent<RawImage>();
        //pic2 = gameObject.GetComponent<RawImage>();
        //pic3 = gameObject.GetComponent<RawImage>();
        show_button.SetActive(false);
        save1.SetActive(false);
        save2.SetActive(false);
        save3.SetActive(false);
        MealType = TypeOfMealPage.Meal_Type;       
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError(
                  "Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    protected virtual void InitializeFirebase()
    {
        
        FirebaseApp app = FirebaseApp.DefaultInstance;
        app.SetEditorDatabaseUrl("https://cauldron-493c1.firebaseio.com/");
        if (app.Options.DatabaseUrl != null) app.SetEditorDatabaseUrl(app.Options.DatabaseUrl);
        REF = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void Generate_Recipes()
    {
        FirebaseDatabase.DefaultInstance.GetReference(MealType).
        GetValueAsync().ContinueWith(task =>
        {
        if (task.IsCompleted)
        {
            DataSnapshot snapshot = task.Result;
            foreach (DataSnapshot recipe in snapshot.Children)
            {
                string line = ""; //to concatenate all in the ingredients of each recipe                            
                DataSnapshot type = recipe.Child("Type"); //internet or original recipe?              
                string Type = (string)type.Value; //convert type to string   
                if (Type != "internet") //ingredients for such recs are stored as a string
                    {
                        DataSnapshot ings = recipe.Child("Ingredients");
                        line = (string)ings.Value;
                        string[] s  = ((string)ings.Value).Split(',');
                        int di = s.Length; //no. ingredients for each recipe
                        int sc = di;
                        foreach (string ingredient in s)
                        {                                                     
                            if (IngredientSelection.UserIngredients.Contains(ingredient))
                            {
                                sc--; // this means the user has this ingredient, need to worry about 1 less ingredient
                            }
                        }
                        if (sc == di) continue; //that means user has no ingredient for this particular recipe
                        Score.Add(recipe.Key, sc); //recipe: score
                        results.Add(recipe.Key, new string[] { Type, line,(string)recipe.Child("Steps").Value,"No Link"});                       
                        continue;
                    }

                int data_ings = (int)recipe.Child("Ingredients").ChildrenCount; //no. ingredients for each recipe
                int score = data_ings;
                DataSnapshot ingredients = recipe.Child("Ingredients");
                foreach (DataSnapshot ingredient in ingredients.Children)
                {
                    string ing = (string)ingredient.Value;
                    line += ing + " , ";
                    if (IngredientSelection.UserIngredients.Contains(ing))
                    {
                        score--; // this means the user has this ingredient, need to worry about 1 less ingredient
                    }
                }
                if (score == data_ings) continue; //that means user has no ingredient for this particular recipe
                Score.Add(recipe.Key, score); //recipe: score
                results.Add(recipe.Key, new string[]{Type,line,(string)recipe.Child("Steps").Value,(string)recipe.Child("Link").Value});              
                }
                if (Score.Count == 0) nothing = true;
                show_button.SetActive(true);
                status.text = "Done!";
            }
        });
          
    }
    public void ProcessButtonPressed()
    {
        status.text = "Processing...";
        Generate_Recipes();       
    }
 
    IEnumerator setImage(string url1, string url2, string url3)
    {
        if (url1 != "No Link" && url1 != "nil")
        {
            WWW W = new WWW(url1);
            yield return W;
            Texture2D te1 = W.texture;
            pic1.texture = te1;
        }
        
        if (url2 != "No Link" && url2 != "nil")
        {
            WWW WW = new WWW(url2);
            yield return WW;
            Texture2D te2 = WW.texture;
            pic2.texture = te2;
        }
               
        if (url3 != "No Link" && url3 != "nil")
        {
            WWW WWW = new WWW(url3);
            yield return WWW;
            Texture2D te3 = WWW.texture;
            pic3.texture = te3;
        }
               
        
        
        
    }

    public void ShowButtonPressed()
    {
        
        string selection = "You selected: " + string.Join(" , ", IngredientSelection.UserIngredients.ToArray());
        UsersSelection.text = selection;
        int i = 0;
        if (nothing == true)
        {
            t1.text = "no recipes found";
            return;
        }
        foreach (KeyValuePair<string, int> recipe in Score.OrderBy(key => key.Value))
        {  

            if (i == 3) break;
            if (i == 0)
            {
                int1 = results[recipe.Key][0] == "internet" ? true : false;
                t1.text = recipe.Key;
                i1.text = results[recipe.Key][1];
                r1.text = results[recipe.Key][2];
                url1 = results[recipe.Key][3];
                i++;
            }
            else if (i == 1)
            {
                int2 = results[recipe.Key][0] == "internet" ? true : false;
                t2.text = recipe.Key;
                i2.text = results[recipe.Key][1];
                r2.text = results[recipe.Key][2];
                url2 = results[recipe.Key][3];
                i++;
            }
            else if (i == 2)
            {
                int3 = results[recipe.Key][0] == "internet" ? true : false;
                t3.text = recipe.Key;
                i3.text = results[recipe.Key][1];
                r3.text = results[recipe.Key][2];
                url3 = results[recipe.Key][3];
                i++;
            }           
        }
        StartCoroutine(setImage(url1, url2, url3));
        if (Guest == false)
        {
            save1.SetActive(true);
            save2.SetActive(true);
            save3.SetActive(true);
        }
    }
    public void Click_one()
    {
        if (int1 == true)
        {
            Application.OpenURL(r1.text);
        }
        else //open new page or scene containing the full steps
        {

            store = r1.text;
            SceneManager.LoadSceneAsync("NonInternet");
        }
    }

    public void Click_two()
    {
        if (int2 == true)
        {
            Application.OpenURL(r2.text);
        }
        else //open new page or scene containing the full steps
        {
            store = r2.text;
            SceneManager.LoadSceneAsync("NonInternet");
        }
    }

    public void Click_three()
    {
        if (int3 == true)
        {
            Application.OpenURL(r3.text);
        }
        else //open new page or scene containing the full steps
        {
            store= r3.text;
            SceneManager.LoadSceneAsync("NonInternet");
        }
    }

    public void Save_one()
    {
        FirebaseDatabase dbRef = FirebaseDatabase.DefaultInstance;
        dbRef.GetReference("Users").Child(UserName).Child("Saved").Child(t1.text).Child("Steps").SetValueAsync(r1.text);
        status.text = "Saved " + t1.text + '!';
        string type = (int1 == true) ? "internet" : "original";
        dbRef.GetReference("Users").Child(UserName).Child("Saved").Child(t1.text).Child("Type").SetValueAsync(type);
        
    }

    public void Save_two()
    {
        FirebaseDatabase dbRef = FirebaseDatabase.DefaultInstance;
        dbRef.GetReference("Users").Child(UserName).Child("Saved").Child(t2.text).Child("Steps").SetValueAsync(r2.text);
        status.text = "Saved " + t2.text + '!';
        string type = (int2 == true) ? "internet" : "original";
        dbRef.GetReference("Users").Child(UserName).Child("Saved").Child(t2.text).Child("Type").SetValueAsync(type);
    }

    public void Save_three()
    {
        FirebaseDatabase dbRef = FirebaseDatabase.DefaultInstance;
        dbRef.GetReference("Users").Child(UserName).Child("Saved").Child(t3.text).Child("Steps").SetValueAsync(r3.text);
        status.text = "Saved " + t3.text + '!';
        string type = (int3 == true) ? "internet" : "original";
        dbRef.GetReference("Users").Child(UserName).Child("Saved").Child(t3.text).Child("Type").SetValueAsync(type);
    }

    public void ReturntotitlePage()
    {
        SceneManager.LoadSceneAsync("titlescreen");
    }
}

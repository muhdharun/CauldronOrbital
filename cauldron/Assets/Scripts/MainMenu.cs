using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public static bool SignedInYet = false;
    public static bool isGuest = true;
    
    public Text _LoginStatus1;
    public Text _LoginStatus2;
    public Text _LoginStatus3;
    public Text isloggedin;

    private void Start()
    {
        isloggedin.text = UIAuth.currentstate;
    }

    public void Login()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
	
    public void StartButtonPressed()
    {
        
        if (!SignedInYet)
        {
            _LoginStatus1.text = "Please login with acc or as guest first";
            Destroy(_LoginStatus1, 5f);
        }
        else
        {
            SceneManager.LoadSceneAsync("TypeOfMeal");
        }

    }

	public void ContributeButtonPressed()
    {
        if (!SignedInYet)
        {
            _LoginStatus2.text = "Please login with acc or as guest first";
            Destroy(_LoginStatus2, 5f);

        }

        else
        {
            SceneManager.LoadSceneAsync("ContributePage");
        }
    }

    public void SavedButtonPressed()
    {
        
        if (isGuest == true)
        {
            _LoginStatus3.text = "Please create an acc first";
            Destroy(_LoginStatus3, 5f);
        }
        else
        {
            
            SceneManager.LoadSceneAsync("SavePage");
        }
        
        
    }

}

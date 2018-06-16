using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public static bool SignedInYet = false;
    public Text _LoginStatus1;
    public Text _LoginStatus2;

    public void Login()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
	
    public void StartButtonPressed()
    {
        if (!SignedInYet)
        {
            _LoginStatus1.text = "Please login with acc or as guest first";
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
        }
    }

}

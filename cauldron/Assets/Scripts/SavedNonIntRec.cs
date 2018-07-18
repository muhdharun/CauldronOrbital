using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SavedNonIntRec : MonoBehaviour {

    public GameObject backbutton;

    public Text steps; 

	void Start () {
        backbutton.SetActive(true);
        steps.text = SavedRecs.store;
	}

    public void Back()
    {
        SceneManager.LoadSceneAsync("SavePage");
    }
}

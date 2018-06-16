using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubmissionPage : MonoBehaviour {

	public void Backbuttonpressed()
    {
        SceneManager.LoadSceneAsync("titlescreen");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NonIntRecipe : MonoBehaviour {

    public Text steps;
    

    private void Start()
    {
        steps.text = RecGen.store;
    }

    public void Back()
    {
        SceneManager.LoadSceneAsync("CauldronAnimation");
    }
}

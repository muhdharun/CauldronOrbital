using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NonIntRecipe : MonoBehaviour {

    public Text steps;
    

    private void Start()
    {
        steps.text = RecipeGeneration.store;
    }

    public void Back()
    {
        SceneManager.LoadSceneAsync("Results");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewType : MonoBehaviour {

    public static string TypeOfMeal;

	public void MainDishPressed()
    {
        TypeOfMeal = "Dish";
        SceneManager.LoadSceneAsync("(NR)MainDish");
    }

    public void DessertPressed()
    {
        TypeOfMeal = "Dessert";
        SceneManager.LoadSceneAsync("(NR)Dessert");
    }

    public void Back()
    {
        SceneManager.LoadSceneAsync("titlescreen");
    }
}

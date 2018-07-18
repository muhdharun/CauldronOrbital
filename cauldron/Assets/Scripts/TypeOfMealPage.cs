using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TypeOfMealPage : MonoBehaviour {

    public static string Meal_Type;

    private void Start()
    {
        Meal_Type = "";
    }

    public void MainDishSelected()
    {
        Meal_Type = "Dish";
        SceneManager.LoadSceneAsync("DishIngredients");
    }

    public void DessertSelected()
    {
        Meal_Type = "Dessert";
        SceneManager.LoadSceneAsync("DessertIngredients");
    }

    public void BackButtonPressed()
    {
        SceneManager.LoadSceneAsync("titlescreen");
    }

}

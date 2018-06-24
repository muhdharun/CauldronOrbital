using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public class RecipeGeneration : MonoBehaviour {

    //every time an acc is created, user's email would appear as a key in FBDB
    //Each user has 2 keys, saved and contributions

    //Algo to generate recs:
    //Compare size of useringredients and ingredient list of each rec in DB depending on type of meal
    // Loop through the data structure that is smaller and find matching ingredients
    //each rec would have a tmp total_score var
    // total_score = number of ingredients to 'catch up' (the lower the better) - votes
    //top 3 shown + show more option 

    public static string MealType; //from TypeOfMealPage script
    int userIngs; //number of user's ingredients (from IngredientSelection)
    bool nothing = false;

    DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;

    Dictionary<string, int> Score = new Dictionary<string, int>();
    //Dictionary<string, string> Recipe_type = new Dictionary<string, string>();
    //Dictionary<string, string> Steps = new Dictionary<string, string>();
    Dictionary<string, string[]> results = new Dictionary<string, string[]>(); 
    // index 0: Recipe_type,1: Ingredients 2: Steps/Website  

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

    public Text UsersSelection;

    // Use this for initialization
    void Start () {
        MealType = TypeOfMealPage.Meal_Type;
        userIngs = IngredientSelection.UserIngredients.Count;
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
                int tmp = userIngs;
                int data_ings = (int)recipe.Child("Ingredients").ChildrenCount; //no. ingredients for each recipe
                int score = data_ings;
                DataSnapshot type = recipe.Child("Type"); //internet or original recipe?
                string Type = (string)type.Value; //convert type to string
                //if (tmp >= data_ings) //loop through data recipe's ingredients instead
                
                    DataSnapshot ingredients = recipe.Child("Ingredients");
                    foreach (DataSnapshot ingredient in ingredients.Children)
                    {
                        string ing = (string)ingredient.Value;
                        line += ing + " ";
                        if (IngredientSelection.UserIngredients.Contains(ing))
                        {
                            score--; // this means the user has this ingredient, need to worry about 1 less ingredient
                        }
                    }
                    if (score == data_ings) continue; //that means user has no ingredient for this particular recipe
                    Score.Add(recipe.Key, score); //recipe: score
                    results.Add(recipe.Key, new string[]{Type,line,(string)recipe.Child("Steps").Value});
                    
                        //Recipe_type.Add(recipe.Key, Type); // recipe : type
                        //Steps.Add(recipe.Key, (string)recipe.Child("Steps").Value);
                    

                    /*else if (tmp <= data_ings) //loop through user's ingredient instead
                        {
                        List<string> dataIng = (List<string>)recipe.Child("Ingredients").Value;
                        foreach (string ingredient in IngredientSelection.UserIngredients)
                        {
                            if (dataIng.Contains(ingredient))
                            {
                                score--; // this means the user has this ingredient, need to worry about 1 less ingredient
                                }
                        }
                        if (score == data_ings) continue;
                        Results.Add(recipe.Key, score); //recipe: score
                        Recipe_type.Add(recipe.Key, Type);
                        Steps.Add(recipe.Key, (string)recipe.Child("Steps").Value); 
                    }*/
                }
                if (Score.Count == 0) nothing = true;
            }
        });
          
    }
    public void GenerateButtonPressed()
    {
        string selection = "You selected: " + string.Join(" , ", IngredientSelection.UserIngredients.ToArray());
        UsersSelection.text = selection;
        //Debug.Log("Generating...");
        Generate_Recipes();
        int i = 0;
        if (nothing == true)
        {
            t1.text = "no recipes found";
            return;
        }
        foreach (KeyValuePair<string,int> recipe in Score.OrderBy(key => key.Value))
        {
            
            if (i == 3) break;
            if (i == 0)
            {
                t1.text = recipe.Key;
                i1.text = results[recipe.Key][1];
                r1.text = results[recipe.Key][2];
                i++;
            }
            else if (i == 1)
            {
                t2.text = recipe.Key;
                i2.text = results[recipe.Key][1];
                r2.text = results[recipe.Key][2];
                i++;
            }
            else if (i == 2)
            {
                t3.text = recipe.Key;
                i3.text = results[recipe.Key][1];
                r3.text = results[recipe.Key][2];
                i++;
            }
        }
    }
    public void ReturntotitlePage()
    {
        SceneManager.LoadSceneAsync("titlescreen");
    }
}

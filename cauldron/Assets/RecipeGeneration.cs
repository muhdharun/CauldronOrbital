using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;

public class RecipeGeneration : MonoBehaviour {

    //every time an acc is created, user's email would appear as a key in FBDB
    //Each user has 2 keys, saved and contributions

    //Algo to generate recs:
    //Compare size of useringredients and ingredient list of each rec in DB depending on type of meal
    // Loop through the data structure that is smaller and find matching ingredients
    //each rec would have a tmp total_score var
    // total_score = number of matched ingredients + votes
    //top 3 shown + show more option 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

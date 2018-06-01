using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using System;

public class LoginPage : MonoBehaviour {
    
    public string email, password;
    

    private void Start()
    {
        FirebaseAuth auth = FirebaseAuth.DefaultInstance;
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Set a flag here indiciating that Firebase is ready to use by your
                // application.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

 
    public void BackLogin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void CreateNewAcc()
    {
        FirebaseAuth auth = FirebaseAuth.DefaultInstance;
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            SceneManager.LoadSceneAsync("LoggedInScreen");
        });


    }

    public void SignInButtonPressed()
    {
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(email, password).
           ContinueWith((task) =>
           {
               if (task.IsCanceled)
               {
                   Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                   return;
               }
               if (task.IsFaulted)
               {
                   Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                   return;
               }

               Firebase.Auth.FirebaseUser newUser = task.Result;
               Debug.LogFormat("User signed in successfully: {0} ({1})",
                   newUser.DisplayName, newUser.UserId);
               SceneManager.LoadSceneAsync("LoggedInScreen");
           });
    }

    public void GuestButtonPressed()
    {
        FirebaseAuth auth = FirebaseAuth.DefaultInstance;
        Debug.Log("Guest button being pressed");
        auth.SignInAnonymouslyAsync().
            ContinueWith((obj) =>
            {
                Debug.Log("Current user is" + auth.CurrentUser);
                SceneManager.LoadSceneAsync("GuestLoginScreen");
            });
    }

    public void SignOutButtonPressed()
    {
        FirebaseAuth auth = FirebaseAuth.DefaultInstance;
        auth.SignOut();
    }
	
}

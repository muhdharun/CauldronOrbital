
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class UIAuth : MonoBehaviour {

    public Text _DebugLog;
    public InputField _Email;
    public InputField _Password;

    Firebase.DependencyStatus _DependencyStatus = Firebase.DependencyStatus.UnavailableOther;
    Firebase.Auth.FirebaseAuth _Auth;
    Firebase.Auth.FirebaseUser _User;

    // Use this for initialization
    void Start ()
    {
        _DependencyStatus = Firebase.FirebaseApp.CheckDependencies();

        if (_DependencyStatus != Firebase.DependencyStatus.Available)
        {
            Firebase.FirebaseApp.FixDependenciesAsync().ContinueWith(task =>
            {
                _DependencyStatus = Firebase.FirebaseApp.CheckDependencies();
                if (_DependencyStatus == Firebase.DependencyStatus.Available)
                {
                    InitializeFirebase();
                }
                else
                {
                    _DebugLog.text = "Could not resolve all Firebase dependencies: " + _DependencyStatus;
                }
            });
        }
        else
        {
            InitializeFirebase();
        }

    }

    private void InitializeFirebase()
    {
        _DebugLog.text = "Setting up Firebase Auth";
        _Auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        _Auth.StateChanged += AuthStateChanged;
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnDestroy()
    {
        _Auth.StateChanged -= AuthStateChanged;
        _Auth = null;
    }

    private void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (_Auth.CurrentUser != _User)
        {
            if (_User == null && _Auth.CurrentUser != null)
            {
                _DebugLog.text = "Signed in " + _Auth.CurrentUser.DisplayName;
            }
            else if (_User != null && _Auth.CurrentUser == null)
            {
                _DebugLog.text = "Signed out " + _User.DisplayName;
            }
            _User = _Auth.CurrentUser;
        }
    }

    public void SignUp()
    {
        string email = _Email.text;
        string password = _Password.text;
        _DebugLog.text = String.Format("Firebase : Attempting to create user {0}...", email);

        _Auth.CreateUserWithEmailAndPasswordAsync(email, password)
          .ContinueWith(HandleCreateResult);
    }

    private void HandleCreateResult(Task<Firebase.Auth.FirebaseUser> authTask)
    {
        if (authTask.IsCanceled)
        {
            _DebugLog.text = "Firebase : User Creation canceled.";
        }
        else if (authTask.IsFaulted)
        {
            _DebugLog.text = "Firebase : User Creation encountered an error.\n" + "Either User already exist or Password must be at least 6 characters long";
        }
        else if (authTask.IsCompleted)
        {
            _DebugLog.text = "Firebase : User Creation completed.\n" + "Welcome " + _Email.text;
            SceneManager.LoadSceneAsync("titlescreen");
        }
    }

    public void SignIn()
    {
        string email = _Email.text;
        string password = _Password.text;
        _DebugLog.text = String.Format("Firebase : Attempting to sign in as {0}...", email);
        _Auth.SignInWithEmailAndPasswordAsync(email, password)
          .ContinueWith(HandleSigninResult);
    }

    private void HandleSigninResult(Task<Firebase.Auth.FirebaseUser> authTask)
    {
        if (authTask.IsCanceled)
        {
            _DebugLog.text = "SignIn canceled.";
        }
        else if (authTask.IsFaulted)
        {
            _DebugLog.text = "Firebase : Login encountered an error.\n" + "Email or Password could be wrong or User does not exist";
        }
        else if (authTask.IsCompleted)
        {
            _DebugLog.text = "Firebase : Login completed.\n" + "Welcome " + _Email.text;
            SceneManager.LoadSceneAsync("titlescreen");
        }
    }

    public void GuestButtonPressed()
    {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        Debug.Log("Guest button being pressed");
        auth.SignInAnonymouslyAsync().
            ContinueWith((obj) =>
            {
                Debug.Log("Current user is" + auth.CurrentUser);
                _DebugLog.text = "Logged in as Guest";
                SceneManager.LoadSceneAsync("titlescreen");
            });
    }

    public void SignOut()
    {
        _Auth.SignOut();
    }

}

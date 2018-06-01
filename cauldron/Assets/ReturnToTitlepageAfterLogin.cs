using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitlepageAfterLogin : MonoBehaviour {

    float delayBeforeLoading = 3f;
    string scenename = "titlescreen";
    private float timeElapsed;

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > delayBeforeLoading)
        {
            SceneManager.LoadSceneAsync(scenename);
        }
    }


}

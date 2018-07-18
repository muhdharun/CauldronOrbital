using Firebase.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TestingOnly : MonoBehaviour {

    public RawImage img;
    string url = "https://firebasestorage.googleapis.com/v0/b/cauldron-493c1.appspot.com/o/3-Ingredient%20Chili-glazed%20Salmon.jpg?alt=media&token=953c7b7b-256a-4099-b99b-ed81f0b7916f";

    // Use this for initialization
    void Start () {
        /*StorageReference imgref = FirebaseStorage.DefaultInstance.GetReferenceFromUrl("gs://cauldron-493c1.appspot.com/3-ingredient Mac & Cheese.jpg");
        imgref.GetDownloadUrlAsync().ContinueWith((Task<Uri> task) =>
        {
            Debug.Log("standby...");
            if (!task.IsFaulted && !task.IsCanceled)
            {
                Debug.Log("waiting...");
                string url = task.Result.ToString();
                Debug.Log(url);
                StartCoroutine(LoadImage(url));
            }
        });*/
	}
	
    public void testbutton()
    {
        StartCoroutine(LoadImage(url));
    }

    public IEnumerator LoadImage(string url)
    {
        WWW W = new WWW(url);
        yield return W;
        Texture2D te = W.texture;
        img.texture = te;
        //Renderer renderer = GetComponent<Renderer>();
        //renderer.material.mainTexture = W.texture;
        //renderer.material.mainTexture.filterMode = FilterMode.Point;
        
    }
}

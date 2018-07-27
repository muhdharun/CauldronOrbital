using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodpopup2 : MonoBehaviour
{

    public float delay;
    public float stop;


    void Start()
    {
        Time.timeScale = 1f;

        gameObject.SetActive(false);
        Invoke("Activate", delay);
        Invoke("Pause", stop);
    }

    void Activate()
    {
        gameObject.SetActive(true);
    }

    void Pause()
    {
        {
            Time.timeScale = 0f;
        }
    }
}

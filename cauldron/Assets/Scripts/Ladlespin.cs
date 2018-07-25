using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladlespin : MonoBehaviour
{
    /*float timeCounter = 0;
    float angle = 0;
    float speed = (2 * Mathf.PI) / 5;
    float radius = 5;
    */
    public static Vector3 pos1 = new Vector3(200, 800f, 0);
    private Vector3 pos2 = new Vector3(600, 800f, 0);
    public float speed = 1.0f;
    public float delay;
    public GameObject ladle;
    public static Vector3 pos3;
    

    // Use this for initialization
    

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ExecuteAfterTime(delay));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
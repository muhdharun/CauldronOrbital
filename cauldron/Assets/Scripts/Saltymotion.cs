using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltymotion : MonoBehaviour {
   float timecounter = 0;
   public float speed;
    public float width;
    public float height;
    public float delay;

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        timecounter += Time.deltaTime * speed;

        float x = Mathf.Cos(timecounter) * width;
        float y = Mathf.Sin(timecounter) * height + 1000;
        float z = 0;
        transform.position = new Vector3(x, y, z);
    }


    // Use this for initialization


    // Update is called once per frame
    void Update () {
        StartCoroutine(ExecuteAfterTime(delay));
	}
}

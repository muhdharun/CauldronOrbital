using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodpopup3 : MonoBehaviour {

    public float delay;

    private void Update()

    {

        StartCoroutine(ExecuteAfterTime(delay));
      
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        int rotatospeedo = 600;
        float step = rotatospeedo * Time.deltaTime;

        Vector3 Targetposition = new Vector3(319f, 550f, 0);
        transform.position = Vector3.MoveTowards(transform.position, Targetposition, step);
        Vector3 myposition = transform.position;



    }
    

}

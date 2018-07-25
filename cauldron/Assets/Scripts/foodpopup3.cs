using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodpopup3 : MonoBehaviour {

    private void Update()

    {
        int rotatospeedo = 600;
        float step = rotatospeedo * Time.deltaTime;
      //  transform.Rotate(Vector3.up, 250 * Time.deltaTime);
        Vector3 Targetposition = new Vector3(319f, 550f, 0);
        transform.position = Vector3.MoveTowards(transform.position, Targetposition, step);
        Vector3 myposition = transform.position;
        if (myposition.y == 900)
        {
            rotatospeedo = 0;
        }
        StartCoroutine(ExecuteAfterTime(5));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        transform.Rotate(Vector3.up, 0 * Time.deltaTime);
        // transform.position = new Vector3(0, 0, 0);

    }

}

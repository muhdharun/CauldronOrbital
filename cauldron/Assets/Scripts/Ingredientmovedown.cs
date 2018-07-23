using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ingredientmovedown : MonoBehaviour
{


    // Update is called once per frame
    // transform.Translate(Vector3.forward * Time.deltaTime);
    //transform.position += transform.forward * Time.deltaTime;
    /*transform.Translate(.05f, 0f, 0f);
    transform.Rotate(0f, 0f, 1f);
    transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);*/
    public float fallSpeed = 1000.0f;
    public float spinSpeed = 250.0f;
    public float delay;

    void Update()
    {
        StartCoroutine(ExecuteAfterTime(delay));
        
         
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
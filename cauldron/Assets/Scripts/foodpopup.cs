using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodpopup : MonoBehaviour
{

    public float delay;

    void Start()
    {

        gameObject.SetActive(false);
        Invoke("Activate", delay);
    }

    void Activate()
    {
        gameObject.SetActive(true);
    }
}


    /*private void Start()
    {
        yield WaitforSeconds(3);
        gameObject.SetActive(false);
     

    }

     private void Update()
     {
         delay--;

         if (delay < 0)
         {
             gameObject.SetActive(true);
         }


     }
    


    /*IEnumerator ExecuteAfterTime(float time)
    {

        yield return new WaitForSeconds(time);

        gameObject.SetActive(false);

        Debug.Log("hello");

    }
    */

   
   


    /*private void Update()

    {
       
        StartCoroutine(ExecuteAfterTime(delay));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        int rotatospeedo = 600;
        float step = rotatospeedo * Time.deltaTime;

        Vector3 Targetposition = new Vector3(375f, 950f, 0);
        transform.position = Vector3.MoveTowards(transform.position, Targetposition, step);
        Vector3 myposition = transform.position;



    }

    
    /*private void Start()
    {
        //transform.Translate(Vector3.up * Time.deltaTime *700, Space.World);
        transform.Translate(, 299.35f, 0);
        
    }
    */
   


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerPlane : MonoBehaviour
{

   // GameObject ToBeDestroyed;
    float time= 0;
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Desinfektionsmittel")
        {
            
               // ToBeDestroyed = other.GetComponent<GameObject>();

            //Destroy(ToBeDestroyed, time);
            Destroy(other.gameObject, time);
            Debug.Log("Destroyed sth");
              

        }

        if (other.tag == "statischerFehler" && id==1)
        {

            // ToBeDestroyed = other.GetComponent<GameObject>();

            //Destroy(ToBeDestroyed, time);
            Destroy(other.gameObject, time);
            Debug.Log("Destroyed sth");


        }


    }
}

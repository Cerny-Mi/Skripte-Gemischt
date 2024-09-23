using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaScriptLampe : MonoBehaviour
{

     public GameObject Licht;
    public void Awake()
    {
        Licht.SetActive(false);



    }
    
    private void OnTriggerEnter(Collider other) //ist scheinbar ne default function??
    {

        //damit nur bestimmte Collider das Licht anschalten!
        if(other.tag == "HandL" || other.tag == "HandR") { 
            Licht.SetActive(true);
        }
       

    }


    private void OnTriggerExit(Collider other) //ist scheinbar ne default function??
    {
        //damit nur bestimmte Collider das Licht anschalten!
        if (other.tag == "HandL" || other.tag == "HandR")
        {
            Licht.SetActive(false);
        }
    }
}

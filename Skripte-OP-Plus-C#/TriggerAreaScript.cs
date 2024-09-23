using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaScript : MonoBehaviour
{
  public GameObject Lever; //bzw teil des buttons der mit dem trigger interagieren soll
    Collider _leverCollider; //collider des buttons

    void Start()
    {
        _leverCollider = Lever.GetComponent<Collider>();
    }

    public int id;
    private void OnTriggerStay(Collider other) //ist scheinbar ne default function??
    {

        if(other == _leverCollider) {

            MyEventHandler.current.LeverTriggerEnter(id);
            //Debug.Log("correct collider entered triggerarea"); 
        }
        

    }


    private void OnTriggerExit(Collider other) //ist scheinbar ne default function??
    {

        if (other == _leverCollider) { MyEventHandler.current.LeverTriggerExit(id);
            //Debug.Log("correct collider exited triggerarea");
        }


    }
}

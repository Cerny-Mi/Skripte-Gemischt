using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statischeFehler : MonoBehaviour
{
    GameObject target;
    Renderer R;

    internal bool mistake;


    // Start is called before the first frame update
    void Start()
    {

        target = this.gameObject;
        R = target.GetComponent<Renderer>();
    }


    public void OnTriggerEnter(Collider other)
    {


        if (other.tag == "HandL" || other.tag == "HandR")
        {
                R.material.color = Color.red;
            }

    }


   
}

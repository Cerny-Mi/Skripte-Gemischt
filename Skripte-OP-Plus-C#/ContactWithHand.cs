using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactWithHand : MonoBehaviour
{
     GameObject target;
    public Material correctM, mistakeM; //fill in @Editor
    Renderer R;

    internal bool mistake;


    // Start is called before the first frame update
    void Start()
    {

        target = this.gameObject;
        mistake = false;
        R = target.GetComponent<Renderer>();
    }


    public void OnTriggerStay(Collider other)
    {

        if (other.tag == "HandL" || other.tag == "HandR")
        {
            R.material = mistakeM;
            mistake = true;

        }


        else if (other.tag == "ElbowL" || other.tag == "ElbowR")
        {

            if (mistakeM == true)
            {
                R.material = correctM;
                mistake = false;
            }
        }


    }



    public void OnTriggerExit(Collider other)
    {

        if (other.tag == "HandL" || other.tag == "HandR")
        {
            R.material = correctM;

        }



    }
}
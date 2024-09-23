using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTimerHandR : MonoBehaviour
{
    //Version, die auf HandCollider-L liegen soll!   


    //Zeit wird HOCHgezählt
    //source: https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
    //source wurde modifizert, um hochzuzählen
    internal int id;
    internal bool _timerIsRunning = false;


    /// <summary>
    /// Interaction via trigger (turn timer on/off)
    /// </summary>
    public void OnTriggerEnter(Collider other) //this Object therefore needs Rigidbody and Collider=is Trigger
    {




        if (other.tag == "ArmL")
        {

            _timerIsRunning = true;
            id = 2;  //for the Timer with Tid 2


        }

        if (other.tag == "ElbowL")
        {

            _timerIsRunning = true;
           id = 3; //for the Timer with Tid 3


        }

    }

    public void OnTriggerExit(Collider other) //this Object therefore needs Rigidbody and Collider=is Trigger
    {


        id = 0;


        if (other.tag == "ArmL")
        {

            _timerIsRunning = false;


        }

        if (other.tag == "ElbowL")
        {

            _timerIsRunning = false;


        }



        



    }




}

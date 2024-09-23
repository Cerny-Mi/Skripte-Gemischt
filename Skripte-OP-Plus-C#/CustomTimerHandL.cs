using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomTimerHandL : MonoBehaviour
{

    //Version, die auf HandCollider-L liegen soll!   


    //Zeit wird HOCHgezählt
    //source: https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
    //source wurde modifizert, um hochzuzählen
    
  //  internal int id;
  
    internal int id;
    internal bool _timerIsRunning = false;

    /// <summary>
    /// Interaction via trigger (turn timer on/off)
    /// </summary>
    /// 

    private void Start()
    {
        _timerIsRunning = false;
    }


    public void OnTriggerEnter(Collider other) //this Object therefore needs Rigidbody and Collider=is Trigger
    {

        

        if ( other.tag == "HandR")
        {
            
            _timerIsRunning = true;
             id = 1;  //for the Timer with Tid 1


        }

        if (other.tag == "ArmR")
        {

           _timerIsRunning = true;
            id = 2;  //for the Timer with Tid 2


        }

        if (other.tag == "ElbowR")
        {

            _timerIsRunning = true;
            id = 3; //for the Timer with Tid 3


        }

    }

    public void OnTriggerExit(Collider other) //this Object therefore needs Rigidbody and Collider=is Trigger
    {


        id = 0;

        if (other.tag == "HandR")
        {
            _timerIsRunning = false;
           
        }



        if (other.tag == "ArmR")
        {

            _timerIsRunning = false;


        }

        if (other.tag == "ElbowR")
        {

            _timerIsRunning = false;

            
        }







    }

    

   
}

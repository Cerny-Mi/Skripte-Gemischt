using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintScript : MonoBehaviour
{
    ///////////Outliner
    public CustomTimerHandL HLS;
    public CustomTimerHandR HRS;


    public Text L, R;



    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (HLS._timerIsRunning == true || HRS._timerIsRunning == true)  //if the other script's id is the same as the id of THIS script here, then...
        {

           

                DisplayTime();
            
        }

        
    }


    void DisplayTime()
    {
       L.text = HLS.id.ToString();
        R.text = HRS.id.ToString();


    }
}

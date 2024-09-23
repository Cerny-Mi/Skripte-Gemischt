using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomColorChanger : MonoBehaviour
{

    ///////////Outliner
    public CustomTimerHandL HLS; 
    public CustomTimerHandR HRS;
    Outline O;
     //für jeden Timer derselbe, wird durch Hände bestimmt
    public int Tid; //für Timer-ID, jeder Timer ein anderer


   



    ///////////Timer
    float currentTime = 0;
    

    //Darstellung der Zeit:
    public Text TimerText;



    void Start()
    {
        O = this.gameObject.GetComponent<Outline>();
        O.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HLS._timerIsRunning == true || HRS._timerIsRunning == true)  //if the other script's id is the same as the id of THIS script here, then...
        {

            if(HLS.id == Tid || HRS.id == Tid )
            { ///////////Material
              // Debug.Log("YELLOW");
              //this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;

                ///////////Outliner
                O.enabled = true;




                ///////////Timer
                if (currentTime < 120) //if time under 2 minutes
                {
                    currentTime += Time.deltaTime;

                }

                else
                {
                    currentTime = 0;
                    HRS._timerIsRunning = false;
                    HLS._timerIsRunning = false;
                }

                DisplayTime(currentTime);
            }
        }

           
        else {
          //  this.gameObject.GetComponent<Renderer>().material.color = Color.white;
            O.enabled = false; }
    }


    void DisplayTime(float timeToDisplay)
    {

        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


    }
}

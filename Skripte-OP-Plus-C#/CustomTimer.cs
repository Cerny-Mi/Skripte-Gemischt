using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomTimer : MonoBehaviour
{

    //Zeit wird HOCHgezählt
    //source: https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
    //source wurde modifizert, um hochzuzählen

    float currentTime = 0;
    bool _timerIsRunning = false; //timer runs only once _timerIsRunning is true;

    //Darstellung der Zeit:
    public Text timeText;
    

    private void Start()
    {
        
    }

    /// <summary>
    /// Intercation via trigger (turn timer on/off)
    /// </summary>
    public void OnTriggerEnter(Collider other) //this Object therefore needs Rigidbody and Collider=is Trigger
    {
        if (other.tag == "HandL" || other.tag == "HandR")
        {

            if (_timerIsRunning == false)
            {
              this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;  
                _timerIsRunning = true; //put the bool to true wherever you want the timer to run}

            }

            else if(_timerIsRunning == true)
            {
                _timerIsRunning = false;
                this.gameObject.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }

    
   

    /// <summary>
    /// Timer Settings
    /// </summary>
    private void Update()
    {

        if (_timerIsRunning) {

            if (currentTime < 120) //if time under 2 minutes
            {
                currentTime += Time.deltaTime;
                
            }

            else
            {
                currentTime = 0;
                _timerIsRunning = false;
            }

            DisplayTime(currentTime);
        }

        

    }

    void DisplayTime(float timeToDisplay)
    {

        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        

    }
}

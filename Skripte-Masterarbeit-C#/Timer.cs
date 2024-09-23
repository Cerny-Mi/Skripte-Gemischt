using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Timer : MonoBehaviour
{


[SerializeField] TextMeshProUGUI timerText;
public Material wallMaterial;
public Color timeCol, defaultWhite; 
public float timeColB, timeColG, factor; 

[SerializeField] float remainingSeconds; 
public bool _timerRunning = true; 




    // Start is called before the first frame update
    void Start()
    {
 timeColB= 1.0f ; 
  timeColG= 1.0f ; 
  factor = 0.00007f;

defaultWhite = new Color(1f,1f,1f,1f);
wallMaterial.color= defaultWhite;

    }

    // Update is called once per frame
    void Update()
    {


if(_timerRunning){


        if (remainingSeconds >0)
        {
            remainingSeconds -= Time.deltaTime; 
            timeColB= timeColB- factor; 
             timeColG= timeColG- factor ; 
            wallMaterial.color= new Color(wallMaterial.color.r , timeColG , timeColB , wallMaterial.color.a);


        if(timeColB < 0 || timeColB ==0){
            timeColB = 1; 
            timeColG = 1; 
        }//color reset END

        }//if timer running END


        else if (remainingSeconds <0)
        {
            remainingSeconds = 0;
            Debug.Log("reached End");

            //a function upon timer end can be added here, f.e. "GameOver(); "

        }//if timer over END


      
        int minutes = Mathf.FloorToInt(remainingSeconds/60);
        int seconds = Mathf.FloorToInt(remainingSeconds%60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


    }//_timerRunning END
}//update END



public void pauseTimer(){


    _timerRunning = false;
    timerText.color = new Color32(40, 40, 40, 200);

}

public void continueTimer(){


    _timerRunning = true;
    timerText.color = Color.white;

}


/*
References:

[21.04.2024]
https://www.youtube.com/watch?v=POq1i8FyRyQ !!!! (= "Make a TIMER & COUNTDOWN in 5 Mins | Unity Tutorial for Beginners" by Rehope Games)

[22.04.2024]
http://digitalnativestudios.com/textmeshpro/docs/ScriptReference/TextMeshPro-color.html





*/



}//doc END

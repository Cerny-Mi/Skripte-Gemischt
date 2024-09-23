using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endingBehavior : MonoBehaviour
{

    public List <Transform> displayedChatParents; 

    [SerializeField]
    int counter =0;

/*
the process is this:
-the different steps with content and choice buttons are divided into groups with a parent, which goes into a slot intise "displayedChatParents".
-whenever a choice button inside the current displayedchatparent gets pressed, the next slot-parent gets displayed while the others disappear

--> aka after press, ALL is deactivated, a counter is brought up then the one corresponding to the counter gets displayed




*/


public void startRunClicked(){

/*
hier rein soll:

[]run results --> 1,2,3
[]3k-explanation  --> 1,2,3
[]bake to homescreen


//example:
  toChangeUI[9].gameObject.SetActive(true);

*/

displayedChatParents[0].gameObject.SetActive(false);
 displayedChatParents[1].gameObject.SetActive(true);
 counter = 1;


}


public void continueButtonPressed(){

    counter++;
    displayedChatParents[(counter-1)].gameObject.SetActive(false);
 displayedChatParents[counter].gameObject.SetActive(true);
}




public void changeToMainMenu(){
 SceneManager.LoadScene(0);
}



public void ExitScene(){
    Debug.Log("quit");
 Application.Quit();
}//exit END





///////////////////////////OLD:

/*
public RectTransform scrollP;

float startY, movedY, moveAmount; 
Vector3 newScrollPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }


 void Update()
    {


        if (Input.touchCount > 0) 
{
	Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero
    

    if(touch.phase == TouchPhase.Began){

        startY= touch.position.y;
            
    }



	if (touch.phase == TouchPhase.Moved) 
	{


        movedY = touch.position.y; 
    
    }//touchphase END

    if(startY != movedY){
        
        moveAmount = movedY - startY;
        newScrollPos = new Vector3(scrollP.localPosition.x, scrollP.localPosition.y + moveAmount, scrollP.localPosition.z);


        //version 1: time
        scrollP.localPosition = Vector3.Lerp(scrollP.localPosition, newScrollPos, Time.deltaTime);



        //version 2: scroll speed:
        //scrollP.localPosition = Vector3.Lerp(scrollP.localPosition, newScrollPos, scrollSpeed);

       
    }



}//if input END

        
    }//update END


public void reactionButton(){

    Debug.Log("I clicked the button at the ending end");
    SceneManager.LoadScene(0);
}

 
*/


 /*
 //NOTES:

[]clamp possible minY and maxY so that user can only scroll within a certain range and not scroll the text into oblivion!





  	// get the touch position from the screen touch to world point
		Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(scrollP.localPosition.x, - touch.position.y, scrollP.localPosition.z));
		// lerp and set the position of the current object to that of the touch, but smoothly over time.
		scrollP.localPosition = Vector3.Lerp(scrollP.localPosition, touchedPos, Time.deltaTime);
	

 //holy.... that actually worked. took the difference between start-touch and moved-touch and added that to the y of the to-be-scrolled-content. and it worked. 
        //[x]now which is better: time.deltatime or some specific float? time-version feels nicer (slower, more consistent) as of now


 
 */

}//doc END

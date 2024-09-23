using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //to access text mesh pro as a component
using UnityEngine.UI; //to access "Image" as a component
using UnityEngine.SceneManagement;

public class buttonBehaviors : MonoBehaviour
{

public Transform playerBody; 
public Raycaster R;
public bool _isButtonHeld = false;
 
 [SerializeField]
 float moveIncrement = 1f; //shall not be zero, because is used together with multiplication (and multiplying by 0 is 0, sooo.....)


[SerializeField]
Timer Timerscript; //hopefully allows to use/manipulate the bool "_timerRunning" of this script

bool _bagOpen, _phoneOpen;
public List <Transform> toChangeUI; 


public Transform OvenTimer;
public List <Sprite> ovenTimerSprites; 


public int ovenTimerCounter = 0; 



//////////////////////////////////////////////////////////////////////////SCENE START STATE OF UI
/*
but why did i want to pass stuff anyway? so that i could start the scene with the chatlog xy open but with the icons turned off UNTIL i reach a certain point in the chatlog!
so this involves the ui which would be handled by script... buttonbehavior. this needs to be planned inside "awake" of buttonbehavior


[]now include the scroll-code and apply it to every open chatlog with the chat-content-placeholder as scrollP!!

*/


void Awake(){ //what happens once the game-scene here (3D-space) is loaded
    Debug.Log(" just woke up");


//basically clicks open the intro chatlog for you:
    phoneIconClicked();
   anyChatClicked(toChangeUI[8]); 



}


public void introExitClicked(){
      toChangeUI[4].gameObject.SetActive(true); //phone button
     toChangeUI[10].gameObject.SetActive(true); //back-to-chat-overview button

    //make itself invisible
     toChangeUI[9].gameObject.SetActive(false);


}






//////////////////////////////////////////////////////////////////////////SMALLER FUNCTIONS
public void ExitScene(){
    Debug.Log("quit");
 Application.Quit();
}//exit END


public void ReturnToMainMenu(){
    Debug.Log("code return to main menu!!");
    SceneManager.LoadScene(0);

 //[]add code for that here!
}//main menu END





//////////////////////////////////////////////////////////////////////////UPDATE
void FixedUpdate(){


//goal: as long as user hold the arrow button, the camParent (= body) gets moved forward by set increments, which creates the illusion of animation.
//stops once user stops holding the button
//is supposed to replace the ground-teleport idea


if(_isButtonHeld){ 

playerBody.GetComponent<Rigidbody>().AddForce(playerBody.transform.forward * moveIncrement, ForceMode.Impulse ); 
moveIncrement+= 0.01f;
//this needed the drag of the rigidbody to be around 15 to move at a slow speed.

}//if held END


}//update END





//////////////////////////////////////////////////////////////////////////FORWARD ARROW BUTTON

//you apparently cant disable/enable rigidbody, but you can turn on/off "Is Kinematic"


public void startPlayerForce(){

playerBody.GetComponent<Rigidbody>().isKinematic = false; //rigidbody cannot be "disabled", but can be turned "kinematic"
_isButtonHeld = true;



}//startForce END

public void endPlayerForce(){

playerBody.GetComponent<Rigidbody>().isKinematic = true;
_isButtonHeld = false;
moveIncrement = 1f;

}//endForce END



//[x]is it needed to make the voids public though? below, try voids without public: yeah, it needs to be public so that the button event handler can access it ^^
//work with list-items here:



//////////////////////////////////////////////////////////////////////////BAG
public void bagIconClicked(){

_bagOpen = !_bagOpen;
//if before it was false, so the bag was closed, it becomes true to open the bag
//if before it was true, so the bag was open, it becomes false to close the bag

//Debug.Log(_bagOpen);

//[x]implement: if clicked (bag/phone), timer stops 
//  if(icon.name == hit.collider.name && !icon.gameObject.activeSelf)  icon.gameObject.SetActive(true);


if(_bagOpen){
//it is clicked to be opened up NOW
//Debug.Log("bag is opening");

if(!toChangeUI[0].gameObject.activeSelf) toChangeUI[0].gameObject.SetActive(true); //if the bagscreen isnt turned on, turn it on now


if(toChangeUI[1].gameObject.activeSelf) toChangeUI[1].gameObject.SetActive(false); //turns phonescreen off
if(toChangeUI[2].gameObject.activeSelf) toChangeUI[2].gameObject.SetActive(false); //turns forwardbutton off
if(toChangeUI[4].gameObject.activeSelf) toChangeUI[4].gameObject.SetActive(false); //turns phonebutton off


Timerscript.pauseTimer(); //pauses timer
}//open END



else if(!_bagOpen){
//it is clicked to close it
//Debug.Log("bag is closing");

if(toChangeUI[0].gameObject.activeSelf) toChangeUI[0].gameObject.SetActive(false); //if bagscreen on, turn it off now.


if(!toChangeUI[2].gameObject.activeSelf) toChangeUI[2].gameObject.SetActive(true); //turns forwardbutton on
if(!toChangeUI[4].gameObject.activeSelf) toChangeUI[4].gameObject.SetActive(true); //turns phonebutton on


Timerscript.continueTimer(); //continues timer
}//close END


}//bagIcon END


//////////////////////////////////////////////////////////////////////////PHONE
public void phoneIconClicked(){

_phoneOpen = !_phoneOpen;

//  if(icon.name == hit.collider.name && !icon.gameObject.activeSelf)  icon.gameObject.SetActive(true);


if(_phoneOpen){
//it is clicked to be opened up NOW
//Debug.Log("bag is opening");

if(!toChangeUI[1].gameObject.activeSelf) toChangeUI[1].gameObject.SetActive(true); //if the phonescreen isnt turned on, turn it on now


if(toChangeUI[0].gameObject.activeSelf) toChangeUI[0].gameObject.SetActive(false); //turns bagscreen off
if(toChangeUI[2].gameObject.activeSelf) toChangeUI[2].gameObject.SetActive(false); //turns forwardbutton off
if(toChangeUI[3].gameObject.activeSelf) toChangeUI[3].gameObject.SetActive(false); //turns bagbutton off


Timerscript.pauseTimer(); //pauses timer
}//open END



else if(!_phoneOpen){
//it is clicked to close it
//Debug.Log("bag is closing");

if(toChangeUI[1].gameObject.activeSelf) toChangeUI[1].gameObject.SetActive(false); //if bagscreen on, turn it off now.


if(!toChangeUI[2].gameObject.activeSelf) toChangeUI[2].gameObject.SetActive(true); //turns forwardbutton on
if(!toChangeUI[3].gameObject.activeSelf) toChangeUI[3].gameObject.SetActive(true); //turns bagbutton on


Timerscript.continueTimer(); //continues timer
}//close END


}//phoneIcon END



//////////////////////////////////////////////////////////////////////////PHONE OVERVIEW
public void returnToOverviewClicked(){
//goes from view of ONE chat to the view of ALL chats

//toChangeUI[1] = phoneScreen
//its children are:
//0 = template of any one chat
//1 = overview of all chats

toChangeUI[1].GetChild(0).gameObject.SetActive(false);
toChangeUI[1].GetChild(1).gameObject.SetActive(true);

}//return to overview END




//////////////////////////////////////////////////////////////////////////PHONE SINGLE CHAT
public void anyChatClicked( Transform clicked){
//goes from view of ALL chat to the view of ONE chat

//toChangeUI[1] = phoneScreen
//its children are:
//0 = template of any one chat
//1 = overview of all chats

//if this is clicked, change the template to display the correct chat id and chat icon


//change the template's chat name to the clicked log's chatname
//string chatID = this.gameObject.GetChild(0).GetComponent<TextMeshProUGUI>().text; 
//Image 


Debug.Log("clicked to open a chat, called: " + clicked);
//now i know why that didnt work. because "this" isnt where i am clicking. "this" is the place the script is on. which means: uiHandler!!
//so i switched ".this" for a Transform "clicked", which gets chosen in inspector upon the anyChatClicked-function call. yes, this is... not ideal. but it works.

//get important data from the chat you WANT to enter/ are clicking the preview on:
TextMeshProUGUI newChatName =  clicked.GetChild(0).GetComponent<TextMeshProUGUI>(); 
Sprite newChatIcon = clicked.GetChild(1).GetComponent<Image>().sprite;
Color newChatIconColor = clicked.GetChild(1).GetComponent<Image>().color; 

//get the content:
Sprite newChatContent = clicked.GetChild(2).GetComponent<Image>().sprite;
Color newChatContentColor = clicked.GetChild(2).GetComponent<Image>().color; 

//change the template's data according to the newChat--- stuff: 
//template-stuff is accessed via toChangeUI-list:
//[5] = chatName
//[6] = chatIcon
//[7] = contentPlaceholder


toChangeUI[5].GetComponent<TextMeshProUGUI>().text = newChatName.text;
toChangeUI[6].GetComponent<Image>().sprite = newChatIcon;
toChangeUI[6].GetComponent<Image>().color = newChatIconColor;

//content
toChangeUI[7].GetComponent<Image>().sprite = newChatContent;
toChangeUI[7].GetComponent<Image>().color = newChatContentColor;
//what is written as "Source Image" in Inspector is, in C#, called ".sprite"
//technically




//update visibilities:
toChangeUI[1].GetChild(0).gameObject.SetActive(true);
toChangeUI[1].GetChild(1).gameObject.SetActive(false);

}//anyChatClicked END



public void ovenTimerClicked(){

   if(ovenTimerCounter == ovenTimerSprites.Count) {
    OvenTimer.gameObject.SetActive(false); 
    R.showCake();
    }

 if(ovenTimerCounter != ovenTimerSprites.Count) {ovenTimerCounter++;
OvenTimer.GetComponent<Image>().sprite = ovenTimerSprites[ovenTimerCounter];
}


 

}//ovenTimerClicked END






/*
To Do:

//add to phonescreen:
[x]overview of other chatlogs
[]chatlog: intro chat (messages will be received in there in realtime, so not just a picture)


[]chatlog: recipes (= a picture that can be scrolled)
[]chatlog: colorcode explanation (= a picture that can be scrolled)
[]chatlog: impressum (= a picture????)

[]chatlog: zum hauptmenü zurückkehren (= button @overview screen)
[x]chatlog: app schließen (= button @overview screen)




*/






/*
//References:


[18.04.2024]
https://docs.unity3d.com/ScriptReference/Application.Quit.html
https://discussions.unity.com/t/how-do-you-call-a-function-with-a-button-unity-5-ui/135524


[19.04.]
https://medium.com/eincode/unity-rigidbody-explained-fb208d0f97f3
https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html




*/


}//doc END

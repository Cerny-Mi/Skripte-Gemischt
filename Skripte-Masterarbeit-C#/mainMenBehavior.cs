using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenBehavior : MonoBehaviour
{

    public List <Transform> displayedChatParents; 

    [SerializeField]
    int counter =0;
    bool _rekordeOpen; 
    public GameObject Rekorde;

/*
the process is this:
-the different steps with content and choice buttons are divided into groups with a parent, which goes into a slot intise "displayedChatParents".
-whenever a choice button inside the current displayedchatparent gets pressed, the next slot-parent gets displayed while the others disappear

--> aka after press, ALL is deactivated, a counter is brought up then the one corresponding to the counter gets displayed




*/



//wanna pass values between scenes: actually, no, I don't need to. I can set game-starting-conditions on the "awake"-call of scripts that only apply to the game-run-scene.
/*
but why did i want to pass stuff anyway? so that i could start the scene with the chatlog xy open but with the icons turned off UNTIL i reach a certain point in the chatlog!
so this involves the ui which would be handled by script... buttonbehavior. this needs to be planned inside "awake" of buttonbehavior
*/


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


public void startRunClicked(){

/*
hier rein soll:


[x]screen zu name und modus
[o]ladescreen
[x]intro zu behScie 
[x]-> und DANN erst szenenwechsel!



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




public void changeToGameRunScene(){
 SceneManager.LoadScene(1);
}


public void Rekordanzeige(){

    if(_rekordeOpen ==false) {Rekorde.SetActive(true); _rekordeOpen =true;}
    else{Rekorde.SetActive(false); _rekordeOpen =false;}


}


public void ExitScene(){
    Debug.Log("quit");
 Application.Quit();
}//exit END


/*
//NOTES:
[x]how to send bools/values set in this scene over into a new scene??? how do they communicate? I don't need to. otherwise, read this:
https://stackoverflow.com/questions/32306704/how-to-pass-data-and-references-between-scenes-in-unity



*/


/*
//REFERENCES:

[07.05.2024]
https://stackoverflow.com/questions/32306704/how-to-pass-data-and-references-between-scenes-in-unity


*/









}//doc END

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Raycaster : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField]
Timer Timerscript;

    public Transform moverBody, doughParent, cakeParent; //this is only important because the movement needs to be applied to the body, not any other possible parent the cam could have.


public buttonBehaviors bb; 


    public Material selectionMat, defaultMat, dragMat; 
    public RectTransform CanvasIconP, exitQuestion; //asign it in script! 
    public List <string> collectedItemList; 
    public List <RectTransform> canvasItemIcons; 

       public List <Transform> teleportPos; 
     public List <GameObject> doughParts; 
     public int doughCounter=0;

    public bool _isOpen , _isTurnedOn, _cakeMixDone, _cakeInsideOven; 
    public Material ovenButtonOn, ovenButtonOff;



[SerializeField] 
Transform dragObjectCurrent; 
Vector3 dragObjPos; 



//    [SerializeFields] 
 //   Transform bagScreen, phoneScreen; 

    //public Vector3 touchedGroundPosition;

    //public float speed = 0.8f;
   // public float m_Thrust = 20f;



    //put this on camera




    void Start()
    {
        //fill list with canvas-children
            foreach (RectTransform child in CanvasIconP) canvasItemIcons.Add(child);





        
        
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < Input.touchCount; ++i)
        { 
            if (Input.GetTouch(i).phase == TouchPhase.Began   ) //[]do I need to declare the TouchPhase.End too??  //|| Input.GetTouch(i).phase == TouchPhase.Moved 
            {




                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hit;

                // Create a particle if hit
                if (Physics.Raycast(ray, out hit) && Timerscript._timerRunning == true) 
                {
                //make sure that no 3d-obj is interactable for as long as ui-screens are turned on! AKA if _timerRunning true, touch stuff. if false, dont touch stuff




                        //Collectibles, Combinables, Draggables, Usables


                //1)[x] to collect collectibles via click: 
                        if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Collectibles")){


                        collectedItemList.Add(hit.collider.name); 

                        foreach (RectTransform icon in canvasItemIcons){
                            if(icon.name == hit.collider.name && !icon.gameObject.activeSelf)  icon.gameObject.SetActive(true);
                        }
                        
                        Debug.Log("added item to list: " +hit.collider.name );
                        Destroy(hit.collider.gameObject, 0.2f); //1 would be one second, which is terribly long
                        //[x]does this destroy its children too? (aka the color-code plane I wanna implement??) Yes, it does.

                        } //if collectibles END





                            /*

                      code from ref: https://discussions.unity.com/t/drag-gameobject-with-finger-touch-in-smartphone/170197/2

                            if (Input.touchCount > 0) 
{
	Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero
	
	if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) 
	{
		// get the touch position from the screen touch to world point
		Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
		// lerp and set the position of the current object to that of the touch, but smoothly over time.
		transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
	}
}
                            */


       //register the hit object:
              if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Draggables") ){
                //the part about dragcurrent is there to avoid immediate collectible-dragging-function-chain. so that a secon click needs to happen.

                //


                    //deciding where to spawn a sphere:
                    //bascially exactly where the teleport-point for combinables is, but higher
                    //Vector3 ingredientSpawnPos = new Vector3 (teleportPos[0].position.x, teleportPos[0].position.y + teleportPos[0].localScale.y, teleportPos[0].position.z); 
                    Destroy(hit.collider.gameObject, 0.2f);
                   

                    doughParts[doughCounter].SetActive(true);
                    if(doughCounter != doughParts.Count -1) doughCounter++;  //for as long as the end of the list is not reached, count up
                    //arrays have a "length", lists have a "count"
                     
                     //and once the counter has hit the max length, the cakemix is considered done!:
                     if(doughCounter == doughParts.Count-1){
                        _cakeMixDone = true;
                        doughParent.parent.GetChild(0).gameObject.SetActive(true);//turns the lilac plane on!
                     } //dough done END


                     Debug.Log("ingredient converted into dough!");
                    

              }//draggable END



                //3)[x] to transfer combinables to the kitchen desk, then turn them into draggables:
                        if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Combinables")){

                                Debug.Log("clicked a combinable");
                               // hit.collider.gameObject.layer = LayerMask.NameToLayer("Draggables");


                            // 2.1: put the to-combine-object on the kitchen table (thanks to a helper object in the scene)
                             // hit.collider.gameObject.transform.position = teleportPos.position; 
                             //hit.collider.gameObject.transform.position = new Vector3(teleportPos.position.x + Random.Range(-2f, 2f),teleportPos.position.y ,teleportPos.position.z + Random.Range(-2f, 2f) ); 
                             hit.collider.gameObject.transform.position = new Vector3(

                                (teleportPos[0].position.x + Random.Range(
                                    - hit.collider.gameObject.transform.localScale.x, hit.collider.gameObject.transform.localScale.x) )    * Random.Range(1.25f, 1.3f)    ,
                                    
                                    teleportPos[0].position.y + (hit.collider.gameObject.transform.localScale.y* .52f),   
                                    
                                (teleportPos[0].position.z + Random.Range(
                                    - hit.collider.gameObject.transform.localScale.z, hit.collider.gameObject.transform.localScale.z)
                                    ) * Random.Range(1.25f, 1.3f)

                                  
                                     ); //vector3 END


                            //to ensure that the objects are STANDING on top of the table, it might be best to go: "your center is on the table line (like the helper object) PLUS half of your size above! because the picot is most often in their middle
                            //[]maybe I need to use localPosition for that??


                             //z und x dürfen sich ändern, y nicht 
                             //um variation der objektposis zu schaffen
                             //how do i get the width of ma object???? via transform.localScale !
                             
                             
                               // 2.2: change the color (=material) of the color-code plane
                             //if you make the colour-code-plane ALWAYS the first child (=0) of the interactible object, then changing that plane's material isnt hard at all.

                             // 2.3: change the object's layer to "draggables"
                             hit.collider.gameObject.layer = LayerMask.NameToLayer("Draggables");
                             hit.collider.transform.GetChild(0).GetComponent<Renderer>().material = dragMat;
                             //240625: now a deeper shade of lilac to signal that it is combinable, but for a second time


                            /*
                            To Do:
                            [x]transfer clicked item to kitchen desk
                            []-> refine its ranges
                            [x]change clicked item's layer to "Draggables"
                            [x]change its plane to the draggable-color
                            */

                        } //if combinables END



/*

      //to convert one into a draggable again... i guess...
              if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Draggables")){
                     dragObjectCurrent = hit.collider.gameObject.transform;
                     Debug.Log("touched a dragged");
              }//draggable test END

&&  dragObjectCurrent != hit.collider.gameObject.transform

*/

          



         



                      //special cases for special drags:
                    if(hit.collider.gameObject.layer == LayerMask.NameToLayer("DragToOven") && _cakeMixDone == true){
                //the part about dragcurrent is there to avoid immediate collectible-dragging-function-chain. so that a secon click needs to happen.


                Debug.Log("I am a bowl and I can be put into the oven, soon!");
                hit.collider.gameObject.transform.position = teleportPos[1].position; 
                hit.collider.transform.GetChild(0).gameObject.SetActive(false); //turns the lilac plane off
                _cakeInsideOven = true; //to show the oven-button-press to start the timer
                
                }


           



                //4)[] to open/close or turn on/off upon click on collider:
                        if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Usables")){


                                Transform Parent = hit.collider.gameObject.transform.parent;
                                usableClicked(Parent);

                                









                            /*
                            To Do:

                            //will try to set the joint/the thing actually needing to move as the PARENT of whatever needs to be clicked! 
                            //clicked object = child, the moving/influenced part = ONE parent

                           []determine what kind of object it is
                           []determine based on the what, whether or not and how it needs to be a)turned on/off, b)opened/closed
                           []execute those states (with a bool)

                            */

                        } //if usables END





                        //if user clicked the exit door:
                         if(hit.collider.gameObject.layer == LayerMask.NameToLayer("ExitDoor")){

                                    Debug.Log("clicked on exit");

                                    //ask for permission before changing scene
                                    exitQuestion.gameObject.SetActive(true);

                         }



                    
                } //physics raycast END
            }//touchphase.began END


        }//for int END
        
    }//update END


public void clickedToExitDoor(){
 Debug.Log("changing scene");
 SceneManager.LoadScene(2);
}

public void clickedToStayInside(){
exitQuestion.gameObject.SetActive(false);
}



/*
//DRAG JAIL:
 if (Input.GetTouch(i).phase == TouchPhase.Moved)
 {


if(dragObjectCurrent !=null){


 Ray newray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hit;

                // Create a particle if hit
                if (Physics.Raycast(newray, out hit) && Timerscript._timerRunning == true) 
                {
                        dragObjectCurrent.position = hit.transform.position;
                    
                   // dragObjectCurrent.position = Vector3.Lerp(dragObjPos, hit.transform.position, Time.deltaTime);


                }

                  } //if draggables END


 }//touchphase.moved END


*/


/*
//for where to move it...
i guess i NEED to use the raycaster again, to get the 3d-touchposition. a helper could then be positioned to show where the click went.and it should not go through other object and shouldnt be allowed to turn.
[]3dpos via raycaster
[]apply to helper (=tester object)
[]do not allow helper-rotation to change

-this is with screentoworldpoint. cant i do this with raycaster instead???
//Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(i).position.x, 0, 0));
//Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(i).position.x,  0, Input.GetTouch(i).position.y));

[]could i use this to lerp camturn too??


*/








void usableClicked(Transform P){


/*
Creation Notes:

-is its own function to check for switch cases separately. 
[]maybe I can turn EVERY interaction-object-if-thingy into its own function?
-the point of rotation needs to be set to "Pivot" for the parent object via Editor (>>Scene (Window) >>the option on the upper left)
-the thing to click on is NOT the joint/parent. that parent needs to be visually hidden (= collider & mesh renderer turned off!! ). the parent is only there to help guide the rotation of open/close 
OR to be the light source which can be turned on/off etc.

-when I later replace the placeholder objects with real ones, I not only need to look out for the position, rotation and mesh, but also to reposition the old /set a new joint/hinge object 

//Debug.Log("clicked a usable, its parent is: " + P);

_isOpen -> for things that open/close (fridge, cupboard, oven, window)
_isTurnedOn -> for things that can be turned off or on (lamps, devices etc.)


*/



switch (P.name){

    case "ovenDoorHingeP":
   


    if(_isOpen == true){
        //supposed to close now
        P.rotation = Quaternion.Euler(0,0,0);
     }
    if (_isOpen == false){
        //supposed to open now
        P.rotation = Quaternion.Euler(0,0,-81.546f);
        //   Quaternion rotation = Quaternion.Euler(0, 30, 0);
    }

     _isOpen = !_isOpen;
     Debug.Log(_isOpen);
    break; 



    case "fridgeJointP":

    if(_isOpen == true){
        //supposed to close now
        P.rotation = Quaternion.Euler(0,0,0);
     }
    if (_isOpen == false){
        //supposed to open now
        P.rotation = Quaternion.Euler(0,92.839f,0);
        //   Quaternion rotation = Quaternion.Euler(0, 30, 0);

        //y:92.839
    }

     _isOpen = !_isOpen;
     Debug.Log( _isOpen);

    break;



    case "ovenButtonP":
    /*
    //idea for oven button:
[x]turn on via ovenbutton -> a light on oven turns on through it and the button itself gets pushed in a little! -> or instead of "light turns on", the "light" might change material from opaque grey to emission material
[x]turn off oven  -> the light on oven turns off through it and the button itself gets pushed out a little!
[x]what if some inside light turns on as well? something red and fiery to show THIS.IS.ON! ?

children of this Parent = 
0 = ovenLight = should change material depending on bool (an emission vs a grey opaque material)
1 = ovenBackdropRed = looks red to signal that inside is On!
2 = ovenOnButton = should change its x-position depending on bool (if on = moved into oven, if off = moved out of oven)
3 = color code plane
    */

    Transform Button = P.GetChild(2).transform;
    Renderer Light = P.GetChild(0).GetComponent<Renderer>();
    Renderer OvenBackdrop = P.GetChild(1).GetComponent<Renderer>();

    if(_isTurnedOn == true){
        //supposed to turn off now
        Light.material = ovenButtonOff;   
        OvenBackdrop.material = ovenButtonOff; 
        
        Button.localPosition = new Vector3( 0f , Button.localPosition.y, Button.localPosition.z); 
        //if localPosition not used, the button will use world space which will then look different than in the scene/editor
     }


    if (_isTurnedOn == false){
        //supposed to turn on now
        Light.material = ovenButtonOn;
        OvenBackdrop.material = ovenButtonOn;

        Button.localPosition  = new Vector3( -0.28f , Button.localPosition.y, Button.localPosition.z); 


        //for cake-baking-process: 
         if(_cakeInsideOven==true && _isOpen==false){ //to both make sure that the oven is turned on and the door closed
            Debug.Log("the dough is inside and the oven is on, so now show the timer!");
            bb.OvenTimer.gameObject.SetActive(true);

        }



    }

     _isTurnedOn = !_isTurnedOn;
     Debug.Log( _isTurnedOn);
    break;


     default:
            print ("default case");
            break;


}//switch END
}//usableClicked END





public void showCake(){

doughParent.parent.gameObject.SetActive(false); //turns off the bowl
cakeParent.gameObject.SetActive(true);

}













/*

// Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hit;

                // Create a particle if hit
                if (Physics.Raycast(ray, out hit) && Timerscript._timerRunning == true) 
                {

                           
                           
                           
                            To Do:


                            //do i need to rewrite the entire thing script for this? aka one for just tip, another for whole drag behavior?
                            because right now only TouchPhase.Began is used, not TouchPhase.Moved or TouchPhase.End

                            //the entire big if-method is dependend on phase = touchphase.began
                            //maybe i can transfer the drag into a different if

                            [x]test inside phase.began
                            [x]test inside new if-method with phase.moved

                            []allow item to be dragged around if touch = dragged
                            []detect if user dragged item into a target collider
                            []detect if the dragged item falls in line with what is supposed to hit the target 
                            []if target-collider hit, then destroy dragged item and log it in a "added this to ____" list

                            make that process work for:
                            []cake-ingredients to bowl
                            []bowl to oven (+ its subsequent cake=collectible, bowl disappears)


                            code from ref: https://discussions.unity.com/t/drag-gameobject-with-finger-touch-in-smartphone/170197/2



                            if (Input.touchCount > 0) 
{
	Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero
	
	if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) 
	{
		// get the touch position from the screen touch to world point
		Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
		// lerp and set the position of the current object to that of the touch, but smoothly over time.
		transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
	}
}


                            */













    /*
    References:

    [10.04.2024]
    https://discussions.unity.com/t/how-to-click-a-3d-object-in-unity3d/85921
    https://docs.unity3d.com/ScriptReference/Input.GetTouch.html 


    [11.04.2024]
    https://docs.unity3d.com/ScriptReference/Object.Destroy.html
   https://discussions.unity.com/t/get-all-children-gameobjects/89443/3
   https://docs.unity3d.com/ScriptReference/RaycastHit-point.html
   https://docs.unity3d.com/ScriptReference/GameObject-layer.html



   [18.04.]
   https://discussions.unity.com/t/if-gameobject-is-active/13770
   https://docs.unity3d.com/ScriptReference/GameObject-activeSelf.html
   https://docs.unity3d.com/ScriptReference/Vector3.Slerp.html
    https://learn.unity.com/tutorial/loops-z2b-1#

   

   [30.04.]
   https://discussions.unity.com/t/drag-gameobject-with-finger-touch-in-smartphone/170197/2



    [01.05]
    https://learn.unity.com/tutorial/switch-statements#5c8a6f91edbc2a067d4753d4
    https://docs.unity3d.com/ScriptReference/Quaternion.Euler.html





    
    
    */




}//doc END

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using System;

public class turnTester : MonoBehaviour
{


public Transform turnTarget;
Quaternion earlierQuat, laterQuat, quatLerper, roundQuat, phoneOrigin;
Quaternion eRounded, lRounded;

public bool _influenceToTime = true;
public float lerpVal = 0.1f; 


 float roundX, roundY, roundZ, roundW; 

 public int collector = 0;

//public float speed = 0.5f;

//[SerializeField] TextMeshProUGUI debugText1, debugText2;







  void getOrigin()
     {
         //_origin = Input.gyro.attitude;
         //phoneOrigin= Input.gyro.attitude;

         
     }

     
      void Start()
     {
       //getOrigin();

       //phoneOrigin = new Quaternion(0.01f, 0.01f, 0.01f, 0.01f);
       phoneOrigin = new Quaternion(0.001f, 0.001f, 0.001f, 0.001f);
         Input.gyro.enabled = true;

 
 
 
 // StartCoroutine(secondsValueComparer());
          
     }//start END


 



void Update()
{

//to get some starting rotation

earlierQuat = ConvertRightHandedToLeftHandedQuaternion(Quaternion.Inverse(phoneOrigin) * Input.gyro.attitude);


float eX = (float)Mathf.Round(earlierQuat.x*100000) / 100000.000000f;
float eY =  (float)Mathf.Round(earlierQuat.y*100000) / 100000.000000f;
float eZ = (float)Mathf.Round(earlierQuat.z*100000) / 100000.000000f;
float eW = (float)Mathf.Round(earlierQuat.w*100000) / 100000.000000f;


eRounded = new Quaternion(eX, eY, eZ, eW);


//100000) / 100000.000000f;
/*
float eX = (float)Mathf.Round(earlierQuat.x*10000) / 10000.00000f;
float eY =  (float)Mathf.Round(earlierQuat.y*10000) / 10000.00000f ;
float eZ = (float)Mathf.Round(earlierQuat.z*10000) / 10000.00000f ;
float eW = (float)Mathf.Round(earlierQuat.w*10000) / 10000.00000f;
*/



//Debug.LogFormat("earlier = {0}, rounded = {1}", earlierQuat, eRounded);
//Debug.LogFormat("original = {0}, rounded = {1}", earlierQuat.x, (float)Mathf.Round(earlierQuat.x*100000) / 100000.00000); //

/*
apparently, the process is like this: 
1.you multiple the original (tiiiiny tiny) value so that round can even deal with it
2.you use round on the now way bigger value
3.after rounding, you divide the rounded value so that it is as small as the original value again. now it is like the original, just rounded
-> it is only about making the value usable for Mathf.Round

*/


//turnTarget.transform.rotation  = roundQuat;
//turnTarget.transform.rotation  = earlierQuat;


//Debug.LogFormat("unrounded = {0}, rounded = {1}", earlierQuat, roundQuat);

 //supposed to wait specific amount of seconds before comparing the two quat-values

}//update END


/**/
void FixedUpdate(){



 laterQuat = ConvertRightHandedToLeftHandedQuaternion(Quaternion.Inverse(phoneOrigin) * Input.gyro.attitude);

float lX = (float)Mathf.Round(laterQuat.x*100000) / 100000.000000f; //1207-version was with 10000, which makes the turn the most stable 
float lY =  (float)Mathf.Round(laterQuat.y*100000) / 100000.000000f;
float lZ = (float)Mathf.Round(laterQuat.z*100000) / 100000.000000f;
float lW = (float)Mathf.Round(laterQuat.w*100000) / 100000.000000f;

lRounded = new Quaternion(lX, lY, lZ, lW);


 if(lRounded.x != eRounded.x || lRounded.y != eRounded.y ||  lRounded.z != eRounded.z  ||  lRounded.w != eRounded.w  ){
      //quatLerper = Quaternion.Lerp(earlierQuat, laterQuat, Time.deltaTime); 
     // quatLerper = Quaternion.Lerp(earlierQuat, laterQuat, lerpVal); 
      turnTarget.transform.rotation  = laterQuat;
//    Debug.LogFormat("earlier = {1}, later = {0}", lRounded, eRounded);
}//if rounded unlike END

   

/*

float lX = (float)Mathf.Round(laterQuat.x*10000) / 10000.00000f; //1207-version was with 10000, which makes the turn the most stable 
float lY =  (float)Mathf.Round(laterQuat.y*10000) / 10000.00000f ;
float lZ = (float)Mathf.Round(laterQuat.z*10000) / 10000.00000f ;
float lW = (float)Mathf.Round(laterQuat.w*10000) / 10000.00000f;


*/




/*
  if(laterQuat.x != earlierQuat.x || laterQuat.y != earlierQuat.y ||  laterQuat.z != earlierQuat.z  ||  laterQuat.w != earlierQuat.w  ){
      //quatLerper = Quaternion.Lerp(earlierQuat, laterQuat, Time.deltaTime); 
     // quatLerper = Quaternion.Lerp(earlierQuat, laterQuat, lerpVal); 
      turnTarget.transform.rotation  = laterQuat;
   // Debug.LogFormat("earlier = {1}, later = {0}", lRounded, eRounded);
}//if original unlike END
*/
 

} //Fixed END




/*

   IEnumerator secondsValueComparer(){



    yield return new WaitForSeconds(0.05f);
    lerpCalculator();
   
   }//comparer END



   void lerpCalculator(){


 laterQuat = ConvertRightHandedToLeftHandedQuaternion(Quaternion.Inverse(phoneOrigin) * Input.gyro.attitude);

float lX = (float)Mathf.Round(laterQuat.x*100000) / 100000.00000f;
float lY =  (float)Mathf.Round(laterQuat.y*100000) / 100000.00000f ;
float lZ = (float)Mathf.Round(laterQuat.z*100000) / 100000.00000f ;
float lW = (float)Mathf.Round(laterQuat.w*100000) / 100000.00000f;

lRounded = new Quaternion(lX, lY, lZ, lW);



    if(lRounded.x != eRounded.x || lRounded.y != eRounded.y ||  lRounded.z != eRounded.z  ||  lRounded.w != eRounded.w  ){
      //quatLerper = Quaternion.Lerp(earlierQuat, laterQuat, Time.deltaTime); 
      quatLerper = Quaternion.Lerp(earlierQuat, laterQuat, lerpVal); 
      turnTarget.transform.rotation  = quatLerper;
    Debug.LogFormat("earlier = {1}, later = {0}", lRounded, eRounded);

}//if diff END 


   StartCoroutine(secondsValueComparer());

   
   }//lerpCalc END

*/


    


/*
roundX= (float)(Mathf.Round(quatLerper.x*100) / 100.000);
roundY= (float)(Mathf.Round(quatLerper.y*100) / 100.000);
roundZ= (float)(Mathf.Round(quatLerper.z*100) / 100.000);
roundW= (float)(Mathf.Round(quatLerper.w*100) / 100.000);

roundQuat = new Quaternion(roundX, roundY, roundZ, roundW);

turnTarget.transform.rotation  = roundQuat;
//Debug.Log(roundQuat);
*/


/*

     void LateUpdate() //to come at the end
     //LateUpdate is called after all Update functions have been called. 
     {

         //also war der Fehler wirklich bei left-hand/right-hand-orientation-Unterschieden. 
         //Danke an User "mndcr" in Unity Discussions! Link: https://discussions.unity.com/t/unity-c-android-gyro-wrong-orientation/214367/2
      //turnTarget.transform.rotation  = ConvertRightHandedToLeftHandedQuaternion(Quaternion.Inverse(phoneOrigin) * Input.gyro.attitude);

laterQuat = ConvertRightHandedToLeftHandedQuaternion(Quaternion.Inverse(phoneOrigin) * Input.gyro.attitude);






    if(earlierQuat != laterQuat) //if the taken values are not the same, aka over the course of some lines, the movement has changed:
    {


      //lerp between the values and send it to be new cam rotation
      //Quaternion quatLerper = Quaternion.Lerp(earlierQuat, laterQuat, Time.deltaTime); 

    //the last value is supposed to be clamped between 0 and 1. cant i put o.5 in there????
    //Quaternion quatLerper = Quaternion.Lerp(earlierQuat, laterQuat, 0.1f); 

 
    if(_influenceToTime) quatLerper = Quaternion.Lerp(earlierQuat, laterQuat, Time.deltaTime); 

    if(_influenceToTime == false) quatLerper = Quaternion.Lerp(earlierQuat, laterQuat, lerpVal); 


      //though i dont really get time.delta time now... do the different update-types even work as intended (getting some time between two sensor-checks) or does time.deltatime just undo that ???
      
      //version 1: without rounding up
     // turnTarget.transform.rotation  = quatLerper;
      //Debug.Log(quatLerper);



roundX= (float)(Mathf.Round(quatLerper.x*100) / roundVal);
roundY= (float)(Mathf.Round(quatLerper.y*100) / roundVal);
roundZ= (float)(Mathf.Round(quatLerper.z*100) / roundVal);
roundW= (float)(Mathf.Round(quatLerper.w*100) / roundVal);

roundQuat = new Quaternion(roundX, roundY, roundZ, roundW);


turnTarget.transform.rotation  = roundQuat;
Debug.Log(roundQuat);






//public float roundX, roundY, roundZ, roundW; 

     // Debug.Log("lerped difference");
    }//if difference END





//roundX= (float)(Mathf.Round(quatLerper.x*100) / 100.00);
//it worked!! i dont know how, but it did!!
//the more zeros after the . , the more decimal places the rounded value gets!








//Debug.LogFormat("unrounded = {0}, rounded = {1}", earlierQuat, roundQuat);

     }//LateUpdate END
 */


/*
//version 2 : with rounding up
        turnTarget.transform.rotation  = new Quaternion(
          (float)(Mathf.Round(quatLerper.x*100) / 100.00),  
          (float)(Mathf.Round(quatLerper.y*100) / 100.00), 
          (float)(Mathf.Round(quatLerper.z*100) / 100.00), 
          (float)(Mathf.Round(quatLerper.w*100) / 100.00) 
          );
*/


//version 2: quatLerper
/*

      

*/



/*
-to round up to specific decimals:
-var result = (Mathf.Round(TimeTaken * 100)) / 100.0
(source: https://forum.unity.com/threads/rounding-to-2-decimal-places.211666/)

float rounded = (float)(Math.Round((double)f, 4);
[x]test
[]implement fully

*/


 Quaternion ConvertRightHandedToLeftHandedQuaternion (Quaternion rightHandedQuaternion)
     {


   //return version1
      return new Quaternion ( 
            - rightHandedQuaternion.x,
             - rightHandedQuaternion.y,
              rightHandedQuaternion.z,
             rightHandedQuaternion.w);

      
      /*
        //return version2
      return new Quaternion ( 
             rightHandedQuaternion.x,
              rightHandedQuaternion.y,
              rightHandedQuaternion.z,
            - rightHandedQuaternion.w);     
      */

     }//quat END





/*
//notes START
//transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, timeCount * speed);


//it did get a little better.... but how to increase the smoothness? do timecount*speed like shown above? or increase the waiting time between value-takes (between earlierQuat and laterQuat)?

//transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
//-> was trying to do... what with it? oh.. the CAM. i tried to influence the cam TURN with that!
//turnTarget.transform.rotation = unlerpedValues;

[x]try out lerp siehe oben
for this to work, I'd need some older value to compare it to...

[]but why does it stutter upon quick rotation change? like it goes back for a second, then eventually to the correct value. like it slows down???


*/
//notes END




/*
//code jail START:

//debugText.text = string.Format("{0}: {1}", _origin, turnTarget.transform.rotation.x);
if(debugText1.gameObject.activeSelf)debugText1.text = string.Format("{0}", phoneOrigin);
if(debugText2.gameObject.activeSelf)debugText2.text = string.Format("{0}", turnTarget.transform.rotation);


turnTarget.transform.rotation = new Quaternion (

            turnTarget.transform.rotation.x + ((unlerpedValues.x - turnTarget.transform.rotation.x ) * speed),
             turnTarget.transform.rotation.y + ((unlerpedValues.y - turnTarget.transform.rotation.y ) * speed),
             turnTarget.transform.rotation.z + ((unlerpedValues.z - turnTarget.transform.rotation.z ) * speed),
              turnTarget.transform.rotation.w + ((unlerpedValues.w - turnTarget.transform.rotation.w ) * speed)

        ); 



   turnTarget.transform.rotation = new Quaternion (

            ((unlerpedValues.x - turnTarget.transform.rotation.x ) * speed) +  turnTarget.transform.rotation.x,
            ((unlerpedValues.y - turnTarget.transform.rotation.y ) * speed) + turnTarget.transform.rotation.y,
            ((unlerpedValues.z - turnTarget.transform.rotation.z ) * speed) + turnTarget.transform.rotation.z,
            ((unlerpedValues.w - turnTarget.transform.rotation.w ) * speed) + turnTarget.transform.rotation.w

        ); 

   turnTarget.transform.rotation = new Quaternion (

            ((unlerpedValues.x - turnTarget.transform.rotation.x ) * speed) +  turnTarget.transform.rotation.x,
            ((unlerpedValues.y - turnTarget.transform.rotation.y ) * speed) + turnTarget.transform.rotation.y,
            unlerpedValues.z,
            unlerpedValues.w 

        ); 

*/
//codejail END





    /*
    //References:

    [18.04.2024]
    https://docs.unity3d.com/ScriptReference/Transform.Rotate.html
    https://discussions.unity.com/t/unity-c-android-gyro-wrong-orientation/214367/3 !!!!!!!!


    [06.05.2024]
    https://docs.unity3d.com/ScriptReference/Quaternion.Lerp.html


    [10.05.2024]
    https://forum.unity.com/threads/rounding-to-2-decimal-places.211666/


    
    
    */



}//doc END

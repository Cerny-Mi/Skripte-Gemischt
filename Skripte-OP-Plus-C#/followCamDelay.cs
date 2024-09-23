using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamDelay : MonoBehaviour
{

    Transform Avatar; //set in Editor
    //me trying to get Cam's rotation to run it into Follower's rotation. Goal: UI-Buttons always face user
    public GameObject Cam; //set in Editor
    public GameObject masterPlayer;

    public int followDistance; //set in Editor
    private List<Vector3> storedPositions;


   
    



    //source: https://forum.unity.com/threads/how-do-you-make-an-object-follow-your-exact-movement-but-delayed.512787/
    //this lets Avatar follow the Object this script is on follow behind with time-delay (not location-delay)

    void Awake()
    {

        //triggerArea = this.transform.Find("triggerarea-pressed");
        // if (triggerArea) { Debug.Log("found child trigger"); }
        Avatar = masterPlayer.transform.Find("Master-Avatar");
        //if (Avatar) { Debug.Log("found avatar"); }

        storedPositions = new List<Vector3>(); //create a blank list

        if (!Avatar)
        {
            Debug.Log("The Avatar was not set");
        }

        if (followDistance == 0)
        {
            Debug.Log("Please set distance higher then 0");
        }

       


    }




    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {


        storedPositions.Add(transform.position); //store the position every frame

        if (storedPositions.Count > followDistance)
        {
            Avatar.transform.position = storedPositions[0]; //move the player
            Avatar.transform.rotation = Cam.transform.rotation;
            storedPositions.RemoveAt(0); //delete the position that player just move to
            


        }


        
    }
}

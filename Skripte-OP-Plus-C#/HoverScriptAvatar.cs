using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverScriptAvatar : MonoBehaviour
{

    //modified to be a script placed on the avatar itself
    GameObject Avatar;


    GameObject Panel;
    public GameObject Panel1, Panel2; 
    public Material onHoverMat;
    public Material defaultMat;
    public MyEventHandler E;


    int hoverCounter= 0; //soll sagen, wie oft User über object gehovert hat
   // public bool _isOver = false;

    void Start()
    {
        //Avatar = Panel.transform.parent.GetChild(0).gameObject; //gets the parent of Panel first. then gets the parent's child on index number 0

        Avatar = this.gameObject;
        Panel = Panel1;
        E._justSwitched = true;
    }


    


    // Update is called once per frame
    void Update()
    {
        if (E.newSceneID == 1) { Panel = Panel1; } //zeig Panel von szene1
        else if (E.newSceneID == 2) { Panel = Panel2; } //zeig panel von szene2

        if (E._justSwitched == true) {
            Panel1.SetActive(false);
            Panel2.SetActive(false);
           // Debug.Log("BOTH PANELS DEACTIVATED");
            Avatar.GetComponent<MeshRenderer>().material = defaultMat;
            hoverCounter = 0;


            E._justSwitched = false;
            
        }


      
       









    }




    //pingpong spielen mit 2 functions. lol

    /* public  void OnTriggerEnter(Collider other)
{

   if (other.tag == "Hand")
   {
       R.material = mistakeM;
       //Looker.SetActive(true);
       mistake = true;

   }*/

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HandR")
        {
           
           

            //m_Animator.SetBool("Jump", true);


            //Debug.Log("IS COLLIDING 1/2");
            //Schritt 1
            if (hoverCounter == 0)
            {
                Avatar.GetComponent<MeshRenderer>().material = onHoverMat;
                Panel.SetActive(true);
                hoverCounter = 1;
               // Debug.Log("IS COLLIDING 2/2");
            }


            //Schritt 3
            if (hoverCounter == 2)
            {

                hoverCounter = 3;

                Avatar.GetComponent<MeshRenderer>().material = defaultMat;
                Panel.SetActive(false);



            }
        }



        
    }

   

    public void OnTriggerExit(Collider other)
    {


        if (other.tag == "HandR")
        {  // Schritt 2
            if (hoverCounter == 1) //erstes verlassen des hovers
            {
                hoverCounter = 2;
            }


            //Schritt 4 & return
            if (hoverCounter == 3) //zweites verlassen des hovers
            {

                hoverCounter = 0; //hovervorgang zurücksetzen

            }
        }


       



    }
}


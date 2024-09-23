using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtUser : MonoBehaviour
{
    
    public GameObject Cam; //set in Editor
                           // public GameObject Looker;

    GameObject Looker;

   

    void Start()
    {
        Looker = this.gameObject; //du legst das Script auf das Objekt (Looker), welches sich mit der Cam mitdrehen soll

    }

    // Update is called once per frame
    void Update()
    {

        
            Looker.transform.rotation = Cam.transform.rotation;
          

    }
}

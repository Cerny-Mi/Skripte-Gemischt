using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasserhahnController : MonoBehaviour
{

    public GameObject WasserPrefab;
    GameObject WasserInstant;
    //public int numInstants;
    public Transform spawnPoint;
    public GameObject WasserhahnSignal;
    public Material WHSDefault, WHSActive;
    Renderer R;

   public float minPos = -0.02f;
    public float maxPos = 0.02f;

    //Bestimmung von Scale:
    public float minScale = 0.002f;
    public float maxScale = 0.010f;


    public void Start()
    {

        R = WasserhahnSignal.GetComponent<Renderer>();

    }

    

    private void OnTriggerStay(Collider other) //ist scheinbar ne default function??
    {

        //damit nur bestimmte Collider das Licht anschalten!
        if (other.tag == "HandL" || other.tag == "HandR")
        {
            

            WasserInstant = Instantiate(WasserPrefab, spawnPoint.position, Quaternion.identity); //spawnPoint.position means "the vector3 about spawnPoint's Transform's position"
                 WasserInstant.SetActive(true);
                WasserInstant.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);

                WasserPrefab.transform.position = new Vector3(spawnPoint.position.x , spawnPoint.position.y + Random.Range(minPos, maxPos), spawnPoint.position.z); //remember, in unity zeigt Y nach oben!!
            R.material = WHSActive;


           int time = Random.Range(0, 10);
            Destroy(WasserInstant, time);



        }


    }

  
    


    private void OnTriggerExit(Collider other) //ist scheinbar ne default function??
    {
        //damit nur bestimmte Collider das Licht anschalten!
        if (other.tag == "HandL" || other.tag == "HandR")
        {

            R.material = WHSDefault;
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverHandlerPrefabs : MonoBehaviour
{

    //dieses script soll liegen auf: master der gesamten box/des gesamten geräts. quasi der Boss des Seifenspenders oder Wasserspender etc.
   HingeJoint _joint; //im editor einstellen
    public int id; //die id des levers
    public Transform triggerArea;
    public Transform spawnPoint;

    public ContactWithHand C;

    //Destroy listed Instants
  //  private List<GameObject> Instances;
    

    //Version partikelsystem
  //  public GameObject ParticleSys; //muss im Editor reingezogen werden

    //Version Prefab:
    public GameObject DesiPrefab;
    GameObject DesiInstant;

    //Bestimmung von Position:
   // float Randomx, Randomy, Randomz; // ohen randomy, denn höhe soll immer dieselbe bleiben
   public  float minPos = -0.02f;
   public  float maxPos =0.02f;

    //Bestimmung von Scale:
   public float minScale = 0.003f;
    public float maxScale= 0.025f;

   public int numInstants = 5; //number of at-once spawned instances


    public Transform lever;
    /*ParticleSystem ps;
    bool psAct;*/

    //SOUND///
    AudioSource source1;
    public AudioClip clip1;


    private void Awake()
    {

        //Instances = new List<GameObject>();


        /*   ps = ParticleSys.GetComponent<ParticleSystem>();
           if (ps) { Debug.Log("found particlesystem"); }*/
        source1 = this.GetComponent<AudioSource>();
        source1.loop = false;


       






    }


    private void Start()
    {


        MyEventHandler.current.onLeverTriggerEnter += OnLeverPressed;
        MyEventHandler.current.onLeverTriggerExit += OnLeverReleased;
    }



   

    private void OnLeverPressed(int id)
    {

        /*if(id == this.id && mistake){}
         
         
         
         */

        if(id == 2)
        {

           // numInstants = 20;
            maxScale = 0.010f;


           minPos = -0.025f;
           maxPos = 0.025f;

           // Debug.Log("WASSER ");
        }

        if (id == this.id)
        {



            if (!C.mistake) {
                // when mistake not done

                //for-version
                /*  for (int i = 0; i < numInstants; i++)
                {

                    DesiInstant = Instantiate(DesiPrefab, spawnPoint.position, Quaternion.identity); //spawnPoint.position means "the vector3 about spawnPoint's Transform's position"
                    DesiInstant.SetActive(true);
                    DesiInstant.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);

                    DesiInstant.transform.position = new Vector3(spawnPoint.position.x , spawnPoint.position.y + Random.Range(minPos, maxPos), spawnPoint.position.z); //remember, in unity zeigt Y nach oben!!
                    
                }*/
                

                //version OHNE for:
               DesiInstant = Instantiate(DesiPrefab, spawnPoint.position, Quaternion.identity); //spawnPoint.position means "the vector3 about spawnPoint's Transform's position"
                DesiInstant.SetActive(true);
                DesiInstant.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);

                DesiInstant.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y + Random.Range(minPos, maxPos), spawnPoint.position.z);



                int time = Random.Range(0, 20);
                Destroy(DesiInstant, time);



                if (!source1.isPlaying)
                {       //spielt Sound nur ab wenn kein Sound bereits läuft. Verhindert Dopplungen. Danke, Internet!
                    source1.pitch = 1;
                    source1.PlayOneShot(clip1);
                }
            }
           

            else if (C.mistake)
            { // when mistake IS done


                if (!source1.isPlaying)
                {
                    source1.pitch = 4;
                    source1.PlayOneShot(clip1);
                    Debug.Log("MISTAKE SOUND");

                }
            }




        }

    }

    private void OnLeverReleased(int id)
    {

        if (id == this.id)
        {
            //hier kommt rein, was passiert wenn lever in das triggerfeld kommt
            //aber nur, wenn die IDs übereinstimmen
            
        }


    }

    private void OnDestroy()
    //ist notwendig, falls das obj durch irgendwas gelöscht wird, damit der code nicht krachen geht
    {
        MyEventHandler.current.onLeverTriggerEnter -= OnLeverPressed;
        MyEventHandler.current.onLeverTriggerExit -= OnLeverReleased;
    }

}

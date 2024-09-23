using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverHandler : MonoBehaviour
{

    //dieses script soll liegen auf: master der gesamten box/des gesamten geräts. quasi der Boss des Seifenspenders oder Wasserspender etc.
    HingeJoint _joint; //im editor einstellen
    public int id; //die id des levers
    internal Transform triggerArea;
    internal Transform spawnPoint;

    //Version partikelsystem
    public GameObject ParticleSys; //muss im Editor reingezogen werden

    //Version Prefab:
    public GameObject DesiPrefab;

    internal Transform lever;
    ParticleSystem ps; 
    bool psAct;

    //SOUND///
    AudioSource source1;
    public AudioClip clip1;


    private void Awake()
    {

        ps = ParticleSys.GetComponent<ParticleSystem>();
        if (ps) { Debug.Log("found particlesystem"); }
        source1 = this.GetComponent<AudioSource>();
        source1.loop = false;



        ps.Stop();

        triggerArea = this.transform.Find("triggerarea-pressed");
       // if (triggerArea) { Debug.Log("found child trigger"); }

        spawnPoint = this.transform.Find("SpawnPoint");
        //  if (spawnPoint) { Debug.Log("found child SpawnPoint"); }


        
       

        lever = this.transform.Find("master-lever-position/leverHingeJoint");
       // if (lever) { Debug.Log("found child leverHingeJoint"); }
        _joint = lever.GetComponent<HingeJoint>();

        

    }


    private void Start()
    {

        
        MyEventHandler.current.onLeverTriggerEnter += OnLeverPressed;
        MyEventHandler.current.onLeverTriggerExit += OnLeverReleased;
    }

    private void OnLeverPressed(int id) {

        if (id == this.id)
        {

            //hier kommt rein, was passiert wenn lever in das triggerfeld kommt
            //aber nur, wenn die IDs übereinstimmen

             ps.Play();

            if (!source1.isPlaying) {       //spielt Sound nur ab wenn kein Sound bereits läuft. Verhindert Dopplungen. Danke, Internet!
                source1.PlayOneShot(clip1);
            }



            

            //ParticleSys.SetActive(true);
            Debug.Log("Lever pressed");
            
        }

    }

    private void OnLeverReleased(int id )
    {

        if (id == this.id)
        {
            //hier kommt rein, was passiert wenn lever in das triggerfeld kommt
            //aber nur, wenn die IDs übereinstimmen

            ps.Stop();
            //source1.Stop();

            //ParticleSys.SetActive(false);
            Debug.Log("Lever released");
        }
        

    }

    private void OnDestroy()
        //ist notwendig, falls das obj durch irgendwas gelöscht wird, damit der code nicht krachen geht
    {
        MyEventHandler.current.onLeverTriggerEnter -= OnLeverPressed;
        MyEventHandler.current.onLeverTriggerExit -= OnLeverReleased;
    }

}

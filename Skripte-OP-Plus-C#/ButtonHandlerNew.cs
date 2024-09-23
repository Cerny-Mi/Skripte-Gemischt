using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandlerNew : MonoBehaviour
{
    //dieses Script ist ne Modifizierung von Leverhandler.
    //benötigt: AudioSource, TriggerArea, 
    //auf dem triggerArea muss das Skript "TriggerAreaSkript" liegen
    //id muss angepasst werden bei: ButtonHandler & triggerAreaScript

    //object für Triggerarea muss collider als "is trigger" haben

    //dieses script soll liegen auf: master der gesamten box/des gesamten geräts. quasi der Boss des Seifenspenders oder Wasserspender etc.
    ConfigurableJoint _joint; //im editor einstellen
    public int id; //die id des levers
    internal Transform triggerArea;

    internal Transform button;


    //SOUND///
    AudioSource source1;
    public AudioClip clip1;


    private void Awake()
    {
        source1 = this.GetComponent<AudioSource>();
        source1.loop = false;






        triggerArea = this.transform.Find("podest/trigger-unten");
        if (triggerArea) { Debug.Log("found child triggerarea"); }

        button = this.transform.Find("push"); //dort wo der joint-component liegt
        if (button) { Debug.Log("found child button"); }
        _joint = button.GetComponent<ConfigurableJoint>();



    }


    private void Start()
    {


        MyEventHandler.current.onLeverTriggerEnter += OnLeverPressed;
        MyEventHandler.current.onLeverTriggerExit += OnLeverReleased;
    }

    private void OnLeverPressed(int id)
    {

        if (id == this.id)
        {

            //hier kommt rein, was passiert wenn lever in das triggerfeld kommt
            //aber nur, wenn die IDs übereinstimmen
            

            if (!source1.isPlaying)
            {       //spielt Sound nur ab wenn kein Sound bereits läuft. Verhindert Dopplungen. Danke, Internet!
                source1.PlayOneShot(clip1);
            }


            //ParticleSys.SetActive(true);
            Debug.Log("Lever pressed");

        }

    }

    private void OnLeverReleased(int id)
    {

        if (id == this.id)
        {
            //hier kommt rein, was passiert wenn lever in das triggerfeld kommt
            //aber nur, wenn die IDs übereinstimmen
            
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

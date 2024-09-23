using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FehlertestOptions : MonoBehaviour
{

    //liegt auf Objekt, auf dem der fehler erscheinen soll. 
    //die ausgewählten Funktions löst du beim Interaction Behavior Script (Add New Event Type) des Objekts aus.
    //damit Interaction Behavior Script auf eine function hier zugreifen kann, muss diese public sein.

    Outline OutlineScript;
    GameObject target;
    GameObject Looker;
   public Material defaultM, changeM; //fill in @Editor
    Renderer R;

  //  public int id;

    // Start is called before the first frame update
    void Start()
    {
        target = this.gameObject;
       OutlineScript=  target.GetComponent<Outline>();
        R = target.GetComponent<Renderer>();
        Looker = target.transform.GetChild(0).gameObject; //besser als "Find", sobald es mehrere objekte mit gleichem Namen aber unterschiedlichen...
                                                        //...Parents in einer Szene gibt

        /* MyEventHandler.current.onStartOutline += FehlerOutline;
         MyEventHandler.current.onStartEmission += FehlerEmission;
         MyEventHandler.current.onEndFehler += FehlerEnd;*/

    }


    //functions für events: (damit n object seine eigene id kriegt)

    /* public void FehlerOutline(int id) {

    if (id == this.id)
    {
        OutlineScript.enabled = true;
        Looker.SetActive(true);
    }



}

public void FehlerEmission(int id) {

    if (id == this.id)
    {
        R.material = changeM;
        Looker.SetActive(true);
    }


}



public void FehlerEnd(int id) {

    if (id == this.id) {

        if (OutlineScript.enabled == true)
        {

            OutlineScript.enabled = false;
            Looker.SetActive(false);
        }

        else if (OutlineScript.enabled == false)
        {
            R.material = defaultM;
            Looker.SetActive(false);
        }
    }*/

    public void FehlerOutline() {

            OutlineScript.enabled = true;
            Looker.SetActive(true);
        

    }

    public void FehlerEmission() {

            R.material = changeM;
            Looker.SetActive(true);
         
    }



    public void FehlerEnd() {
        

            if (OutlineScript.enabled == true)
            {

                OutlineScript.enabled = false;
                Looker.SetActive(false);
            }

            else if (OutlineScript.enabled == false)
            {
                R.material = defaultM;
                Looker.SetActive(false);
            }
        

        
    }



    /*private void OnDestroy()
    //ist notwendig, falls das obj durch irgendwas gelöscht wird, damit der code nicht krachen geht
    {
        
        MyEventHandler.current.onStartOutline -= FehlerOutline;
        MyEventHandler.current.onStartEmission -= FehlerEmission;
        MyEventHandler.current.onEndFehler -= FehlerEnd;
    }
*/

}

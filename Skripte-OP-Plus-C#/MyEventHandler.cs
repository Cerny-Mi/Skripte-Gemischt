using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyEventHandler : MonoBehaviour
{

    public static MyEventHandler current;
    bool m_sceneLoaded; //for checking if scene was able to load. If scene cannot load, it cannot be set to active either.


    //Version SetActive
    internal int newSceneID =1;
    public GameObject MasterScene2, MasterScene1;
    internal bool _justSwitched = false;



    //Main Panels
    public GameObject UIOne;
    public GameObject UITwo;


    //Modi-Button:

    public GameObject ModiInhalt;
    //bool _MIactive;

    //Galerie:
    public GameObject GalerieInhalt;

    //Impressum:
    public GameObject ImprInhalt;


 
    

   

    private void Awake()
    {
        current = this;
        MasterScene1.SetActive(true);
        MasterScene2.SetActive(false);


        //The Main Panels
        UIOne.SetActive(true);
        UITwo.SetActive(true);

        //The extra Panels
        /*_HIactive = false; 
         _MIactive = false; */
        ModiInhalt.SetActive(false);
        ImprInhalt.SetActive(false);
        GalerieInhalt.SetActive(false);



    }

    public event Action <int> onLeverTriggerEnter; //int steht als identificationsnummer für verschiedene lever!
    public void LeverTriggerEnter(int id ) //id halt. die id ist ein int
    {

        if (onLeverTriggerEnter !=null)
        { onLeverTriggerEnter(id); }

    }

    public event Action <int> onLeverTriggerExit;
    public void LeverTriggerExit(int id)
    {

        if (onLeverTriggerExit != null)
        { onLeverTriggerExit(id); }

    }

   



    ///////Menü betreffend:///////

    public void ApplicExit() //when this function is called, application will shut down
    {
        
            Debug.Log("quit application");
            Application.Quit();
        

    }
    


    //Version SetActive
    public void SzenenwechselHin() //von s1 zu s2
    {
        MasterScene2.SetActive(true);
        MasterScene1.SetActive(false);
        ModiInhalt.SetActive(false);
        Debug.Log("SCENE2");
        newSceneID = 2;
        _justSwitched = true;

    }

    public void SzenenwechselRueck() //von s2 zu s1
    {

        MasterScene2.SetActive(false);
        MasterScene1.SetActive(true);
        Debug.Log("SCENE1");
        UIOne.SetActive(true);
        newSceneID = 1;
        _justSwitched = true;

    }


        

    public void ButtonModi() 
    {
        
            ModiInhalt.SetActive(true);
            UIOne.SetActive(false);
          

       
    }

    public void ButtonModiRueck()
    {
            ModiInhalt.SetActive(false);
        UIOne.SetActive(true);
        
    }


    //ohne Bool, da die Option mit "Mainpanel kann Screen auch wegschalten" entfallen ist. der einzige Weg, das extrapanel wegzuschalten ist über den roten Knopf (ButtonImpressumRueck)   
    public void ButtonImpressum()
    {

       
            ImprInhalt.SetActive(true);
            UIOne.SetActive(false);
        
    }

    public void ButtonImpressumRueck()
    {
        ImprInhalt.SetActive(false);
        UIOne.SetActive(true);

    }



    public void ButtonGalerie()
    {


        GalerieInhalt.SetActive(true);
        UIOne.SetActive(false);

    }

    public void ButtonGalerieRueck()
    {
        GalerieInhalt.SetActive(false);
        UIOne.SetActive(true);

    }

    
    

    





}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{

    //script zerstört das GameObjekt, auf dem das Skript liegt nach ner bestimmten Zeit. Davon ausgehend, dass das obj existiert.

    GameObject instant;
    float time; //in sekunden

    public float min = 4;
    public float max =15;
    // Start is called before the first frame update
    void Start()
    {
        instant = this.gameObject; 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (instant)
        {

            time = Random.Range(min, max);
            //Destroy(obj, time);
            Destroy(instant, time);

        }
    }
}

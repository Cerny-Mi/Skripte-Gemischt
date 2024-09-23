using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSwap : MonoBehaviour
{

    public GameObject ImageOne, ImageTwo;

    private void Start()
    {
        ImageTwo.SetActive(false);
    }

    // Start is called before the first frame update
    public void showImageOne() {
        ImageTwo.SetActive(false);

    }

    public void showImageTwo() {
        ImageTwo.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gatorCode : MonoBehaviour
{
    public bool isImgOn;
    public Image img;

    void Start()
    {

        img.enabled = true;
        isImgOn = true;
    }

    void Update()
    {

        if (Input.GetKeyDown("g"))
        {

            if (isImgOn == true)
            {

                img.enabled = false;
                isImgOn = false;
            }

            else
            {

                img.enabled = true;
                isImgOn = true;
            }
        }
    }
}


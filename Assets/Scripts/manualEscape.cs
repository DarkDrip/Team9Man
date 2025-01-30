using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manualEscape : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Application has quit.");
        }
    }
}

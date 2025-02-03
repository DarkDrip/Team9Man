using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fullScreen : MonoBehaviour
{
    public void setFullscreen(bool fullscreen)
    {
        if (fullscreen)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            Debug.Log("Fullscreen");
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            Debug.Log("Windowed");
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;


public class sceneChange : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Applicaion has quit");
    }
}

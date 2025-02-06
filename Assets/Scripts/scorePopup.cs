using UnityEngine;

public class scorePopup : MonoBehaviour
{
    public static scorePopup Instance { get; private set; }
    public void positionSet(Ghost ghost, Vector3 position)
    {
        Debug.Log("My position on death is: " + position);
    }
}

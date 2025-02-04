using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passage : MonoBehaviour
{
    public Transform connections;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 position = other.transform.position;
        position.x = this.connections.position.x;
        position.y = this.connections.position.y;
        other.transform.position = position;
        
    }
}

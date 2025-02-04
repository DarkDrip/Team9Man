using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet : Pellet
{
    public float duration = 8f;

    protected override void Eat()
    {
        GameManager.Instance.PowerPelletEaten(this);
    }
}

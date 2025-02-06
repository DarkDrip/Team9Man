using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet : Pellet
{
    public float duration = 12f;

    protected override void Eat()
    {
        GameManager.Instance.PowerPelletEaten(this);
    }
}

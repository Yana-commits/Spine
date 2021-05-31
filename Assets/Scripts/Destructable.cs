using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
     
    public float hitPoints = 1f;

    public float hitPointsCurrent;

    void Start()
    {
       hitPointsCurrent = hitPoints;
    }

    public void Hit(float damage)
    {
        hitPointsCurrent -= damage;

        BroadcastMessage("GetHit");

        if (hitPointsCurrent <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        BroadcastMessage("Destroyed");
    }

}

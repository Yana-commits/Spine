using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    private GameObject owner;
    public GameObject Owner { get => owner; set => owner = value; }

    [SerializeField]
    private float damage = 1f;
    public float Damage { get => damage; set => damage = value; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameObject.Equals(collision.gameObject, Owner))
        {
            Destructable target = collision.gameObject.GetComponent<Destructable>();

            if (target != null)
            {
                target.Hit(Damage);
            }
            Destroy(gameObject);
        }
        
    }
}

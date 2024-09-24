using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitBox : MonoBehaviour
{

    public float swordDamage = 1f;
    public Collider2D swordCollider;

    void Start()
    {
        if (swordCollider == null)
        {
            Debug.Log("Sword collider not set");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Sword hit: " + col.gameObject.name);
        print("a");
    }

}

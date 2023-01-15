using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    GoldFishController goldFishController;

    void Awake()
    {
        goldFishController = FindObjectOfType<GoldFishController>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force, ForceMode2D.Impulse);
        Destroy(gameObject, 3.5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Waste")
        {
            Destroy(gameObject);
        }
      
    }

}

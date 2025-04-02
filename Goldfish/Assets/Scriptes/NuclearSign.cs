using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NuclearSign : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    private Rigidbody2D rg;
    bool wasCollected = false;
    void Start()
    {
        rg = this.GetComponent<Rigidbody2D>();
        rg.velocity = new Vector2(-speed, 0);
    }

    private void Update()
    {
        transform.Rotate(0, 0, -0.07f);
        if (transform.position.x < -GameHandler.screenBounds.x * 2)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.tag== "Player" && !wasCollected)
       {
          wasCollected = true;
          other.gameObject.GetComponent<RadioactiveCharge>().ChangeRadChar();
          Destroy(gameObject);
       }

        if (other.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}

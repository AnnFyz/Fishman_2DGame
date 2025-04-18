using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NuclearSign : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] GameObject particlesPref;
    private Rigidbody2D rg;
    bool wasCollected = false;
    void Start()
    {
        rg = this.GetComponent<Rigidbody2D>();
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, Random.Range(-40, -35));
            rg.velocity = transform.right * -speed;
        }
        else
        {
            rg.velocity = new Vector2(-speed, 0);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            transform.Rotate(0, 0, -0.07f);
        }
           
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
          Instantiate(particlesPref, transform.position, Quaternion.identity);
          SoundManager.Instance.PlaySound("Pickup");
          Destroy(gameObject);
       }
    }
}

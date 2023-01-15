using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NuclearSign : MonoBehaviour
{
    //[SerializeField] int sceneIndex;
    [SerializeField] private float speed = 10.0f;
    private Rigidbody2D rg;
    RadioactiveCharge radiactiveChar;
    GoldFishController sizeController;
    UIProgressBar progressBar;
    void Start()
    {
        rg = this.GetComponent<Rigidbody2D>();
        rg.velocity = new Vector2(-speed, 0);

        radiactiveChar = FindObjectOfType<RadioactiveCharge>();
        sizeController = FindObjectOfType<GoldFishController>();
        progressBar = FindObjectOfType<UIProgressBar>();
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
       if (radiactiveChar != null && other.tag== "Player")
       {
          radiactiveChar.ChangeRadChar();
          Destroy(gameObject);
       }

        if (sizeController != null && sizeController.transform.localScale.x < 6)
        {
            sizeController.ChangeScale();
        }

        if (other.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}

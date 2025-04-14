using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Wastes : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    private Rigidbody2D rg;
    public SpriteRenderer wasteRanSpr;
    bool hasDamaged = false;
    void Start()
    {
        wasteRanSpr = GetComponent<SpriteRenderer>();
        ChangeSpriteWaste();
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            transform.Rotate(0, 0, -15f);
        }

        
        rg = this.GetComponent<Rigidbody2D>();
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
        {
         rg.velocity = new Vector2(-speed, 0);
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            rg.velocity = new Vector2(0, -speed);
        }

    }

    public void ChangeSpriteWaste()
    {
        
        wasteRanSpr.sprite = GameAssets.GetInstance().WasteCollection[Random.Range(0, GameAssets.GetInstance().WasteCollection.Length)];
        wasteRanSpr.sortingOrder = Random.Range(-1, 1);
    }

    private void Update()
    {
        if (transform.position.x < -GameHandler.screenBounds.x *2)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player" && !hasDamaged)
        {
            hasDamaged = true;
            other.GetComponent<RadioactiveCharge>().ChangeHealth(-1);
            Destroy(gameObject);

        }

        if (other.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}

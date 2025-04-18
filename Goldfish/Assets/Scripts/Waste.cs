using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Waste : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] GameObject explosionPref;
    private Rigidbody2D rg;
    public SpriteRenderer wasteRanSpr;
    bool hasDamaged = false;
    void Start()
    {
        wasteRanSpr = GetComponent<SpriteRenderer>();
        ChangeSpriteWaste();
        rg = this.GetComponent<Rigidbody2D>();
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
         rg.velocity = new Vector2(-speed, 0);
        }

        else if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, Random.Range(-40, -35));
            rg.velocity = transform.right * -speed;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
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
            Instantiate(explosionPref, transform.position, Quaternion.identity);
            SoundManager.Instance.PlaySound("ExplosionWaste");
            Destroy(gameObject);

        }

        else if (other.tag == "Bullet")
        {
            Instantiate(explosionPref, transform.position, Quaternion.identity);
            SoundManager.Instance.PlaySound("ExplosionWaste");
            Destroy(gameObject);
        }
    }
}

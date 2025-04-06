using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float minSpeed = 10.0f;
    [SerializeField] private float maxSpeed = 20.0f;
    [SerializeField] private GameObject explosion;
    private Rigidbody2D rg;
    public SpriteRenderer enemyRanSpr;
    public Sprite[] Enemies;
    void Start()
    {

        enemyRanSpr = GetComponent<SpriteRenderer>();
        ChangeSpriteEnemy();
        rg = GetComponent<Rigidbody2D>();
        
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            rg.velocity = new Vector2(Random.Range(-minSpeed, -maxSpeed), 0);
        }

    }

    private void Update()
    {
        if (transform.position.x < -GameHandler.screenBounds.x * 2)
        {
            Destroy(this.gameObject);
        }
    }
    public void ChangeSpriteEnemy()
    {

        enemyRanSpr.sprite = Enemies[Random.Range(0, Enemies.Length -1)];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        RadioactiveCharge radioactiveCont = other.GetComponent<RadioactiveCharge>();
        FishmanController fishmanController = other.GetComponent<FishmanController>();

        if (radioactiveCont != null && other.GetComponent<FishmanController>().isEnemyAttacked == false)
        {
         radioactiveCont.ChangeHealth(-1);
         Destroy(gameObject);

        }
        
        if (fishmanController != null && other.GetComponent<FishmanController>().isEnemyAttacked == true)
        {
            other.GetComponent<FishmanController>().isEnemyAttacked = false;
            Destroy(gameObject);
        }

        if (other.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}

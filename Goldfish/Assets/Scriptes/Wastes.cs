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
    //public Sprite wasteNewRanSpr;
    public Sprite[] Waste;
    UIHealthBar scroller;
    void Start()
    {
        scroller = FindObjectOfType<UIHealthBar>();
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
        
        wasteRanSpr.sprite = Waste[Random.Range(0, Waste.Length -1)];
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
        RadioactiveCharge radiaktiveChar = other.GetComponent<RadioactiveCharge>();
        
        if (radiaktiveChar != null)
        {
           radiaktiveChar.ChangeHealth(-1);
           //scroller.collisionW = true;
           //scroller.ChangeSize();
           //Destroy(gameObject);
            
        }

        if (other.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}

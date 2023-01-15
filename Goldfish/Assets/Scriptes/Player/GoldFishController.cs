using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoldFishController : MonoBehaviour
{
    [SerializeField] private float swimAmount = 100f;
    [SerializeField] private float jumpForce = 10000f;
    [SerializeField] private float movSpeed = 100f;
    [SerializeField] private float rotateSpeed = 3f;
    [SerializeField] private float projectileSpeed = 10f;
    float walking;
    private Rigidbody2D rg2;
    private Vector3 scaleChange;
    private float rotation;
    [SerializeField] private bool isGrounded;
    EnemyController enemy;
    public bool isEnemyAttacked;
    Animator animator;
    public Vector2 lookDirection = new Vector2(1, 0);
    public GameObject projectilePrefab;

    void Awake()
    {
        scaleChange = new Vector3(0.3f, 0.3f, 0.3f);
        rg2 = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        enemy = FindObjectOfType<EnemyController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        Animation();
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
        {
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetMouseButtonDown(0)) && (transform.position.y < GameHandler.screenBounds.y / 4))

            {
                Swim();
            }
        }


        if (SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4)
        {

            Walk();
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) /*&& (transform.position.y < GameHandler.screenBounds.y / 4)*/)

            {
                if (isGrounded == true)
                {
                    Jump();
                    isGrounded = false;
                }
            }

            if (Input.GetMouseButtonDown(2))
            {
                //animator.SetBool("IsSwordPose", true);
                StartCoroutine(ChangeSwordPos());
                isEnemyAttacked = true;
            }

            if (Input.GetMouseButtonDown(1))
            {

                BulletLaunch();
                //StartCoroutine(ChangeShootingPos());

            }
        }

    }
    private IEnumerator ChangeSwordPos()
    {

        animator.SetBool("IsSwordPose", true);
        yield return new WaitForSeconds(0.5f);

        animator.SetBool("IsSwordPose", false);
        yield return new WaitForSeconds(0.5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (gameObject != null)
        {

            Destroy(enemy);
            isEnemyAttacked = false;

        }


    }
    private IEnumerator ChangeShootingPos()
    {
        animator.SetBool("IsShooting", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("IsShooting", false);
        yield return new WaitForSeconds(0.5f);
    }



    void Animation()
    {
        walking = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(walking, 0);
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, 0);
            lookDirection.Normalize();
        }

        animator.SetFloat("MoveX", lookDirection.x);
        if (Mathf.Abs(walking) > 0.01f)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    void Walk()
    {
        transform.position += new Vector3(walking, 0, 0) * Time.deltaTime * movSpeed;
    }
    void Jump()
    {
        rg2.AddForce(Vector2.up * jumpForce);
        animator.SetBool("IsJumping", true);
    }

    //void Rotation()
    //{
    //    walking = Input.GetAxis("Horizontal");
    //    rotation = -Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
    //    rotation = Mathf.Clamp(rotation, -45, 45);
    //    transform.Rotate(0, 0, rotation);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SeaBottom"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
                animator.SetBool("IsJumping", false);
            }
        }
    }

    void Swim()
    {
        rg2.velocity = Vector2.up * swimAmount; // to make swimming repeatable and consistent, work good with gravity 35
    }

    public void ChangeScale()
    {
        transform.localScale += scaleChange;
    }

    void BulletLaunch()
    {
        Debug.Log("test");
        StartCoroutine(ChangeShootingPos());
        GameObject projectileObject = Instantiate(projectilePrefab, rg2.position + Vector2.up * 0.5f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, projectileSpeed); 

    }

}

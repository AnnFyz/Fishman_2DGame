using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishmanController : MonoBehaviour
{
    [SerializeField] private float swimAmount = 100f;
    [SerializeField] private float jumpForce = 10000f;
    [SerializeField] private float movSpeed = 100f;
    [SerializeField] private float rotateSpeed = 3f;
    [SerializeField] private float projectileSpeed = 10f;
    float walking;
    private Rigidbody2D rg2;
    [SerializeField] private bool isGrounded;
    EnemyController enemy;
    public bool isEnemyAttacked;
    Animator animator;
    public Vector2 lookDirection = new Vector2(1, 0);
    public GameObject projectilePrefab;
    public Transform shootOriginLeft;
    public Transform shootOriginRight;
    void Awake()
    {
        rg2 = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        enemy = FindObjectOfType<EnemyController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        Move();
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
            animator.SetBool("IsSwordPose", true);
            StartCoroutine(ChangeSwordPos());
            isEnemyAttacked = true;
        }

        if (Input.GetMouseButtonDown(1))
        {

            BulletLaunch();
            StartCoroutine(ChangeShootingAnim());

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
    private IEnumerator ChangeShootingAnim()
    {
        animator.SetBool("IsShooting", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("IsShooting", false);
        yield return new WaitForSeconds(0.5f);
    }



    void Move()
    {
        walking = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(walking, 0);
        if(move != Vector2.zero)
        {
            lookDirection = move.normalized;
            animator.SetFloat("MoveX", lookDirection.x);
        }

        if (Mathf.Abs(walking) > 0.01f)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        if (isGrounded)
        {
            transform.position += new Vector3(walking, 0, 0) * Time.deltaTime * movSpeed;
        }
    }

    void Jump()
    {
        rg2.AddForce(Vector2.up * jumpForce);
        animator.SetBool("IsJumping", true);
    }


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


    void BulletLaunch()
    {
        StartCoroutine(ChangeShootingAnim());
        Vector3 shootPos = lookDirection.x < 0 ? shootOriginLeft.position : shootOriginRight.position;
        GameObject projectileObject = Instantiate(projectilePrefab, shootPos, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, projectileSpeed);

    }

}

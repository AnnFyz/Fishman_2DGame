using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class FishmanController : MonoBehaviour
{
    [SerializeField] private float swimAmount = 100f;
    [SerializeField] private float jumpForce = 10000f;
    [SerializeField] private float movSpeed = 100f;
    [SerializeField] private float rotateSpeed = 3f;
    [SerializeField] private float projectileSpeed = 10f;
    float walkingX;
    private Rigidbody2D rg2;
    [SerializeField] private bool isGrounded;
    public bool isEnemyAttacked;
    Animator animator;
    public Vector2 lookDirection = new Vector2(1, 0);
    public GameObject projectilePrefab;
    public Transform shootOriginLeft;
    public Transform shootOriginRight;
    PlayerControlls playerInput;
    Vector3 playerScreenPoint;
    Vector2 clickedPos;
    bool canMove = false;
    public bool isSwordPose = false;
    void Awake()
    {
        rg2 = GetComponent<Rigidbody2D>();
        playerInput = new PlayerControlls();
        playerInput.PlayerInput.Tap.performed += EvaluateClick;
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsRunning", true);
    }

    void Update()
    {
        playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        if (playerInput.PlayerInput.ClickAndPoint.ReadValue<Vector2>().x < playerScreenPoint.x)
        {
            Debug.Log("Left");
            lookDirection = Vector2.left;
            animator.SetFloat("MoveX", Vector2.left.x);
        }
        else
        {
            Debug.Log("Right");
            lookDirection = Vector2.right;
            animator.SetFloat("MoveX", Vector2.right.x);
        }


        if (Input.GetMouseButtonDown(2))
        {
            StartCoroutine(ChangeSwordPos());

        }

        if (Input.GetMouseButtonDown(1))
        {
            BulletLaunch();
            StartCoroutine(ChangeShootingAnim());
        }

    }

    void FixedUpdate()
    {
        Move();
    }
    private IEnumerator ChangeSwordPos()
    {
        animator.SetBool("IsSwordPose", true);
        isSwordPose = true;
        yield return new WaitForSeconds(0.5f);

        animator.SetBool("IsSwordPose", false);
        yield return new WaitForSeconds(0.5f);
        isSwordPose = false;
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
        if (canMove && isGrounded)
        {
            Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(clickedPos.x, transform.position.y, transform.position.z));
            rg2.MovePosition(Vector3.MoveTowards(transform.position, target, movSpeed * Time.fixedDeltaTime));
        }
    }

    void Jump()
    {
        if (isGrounded == true)
        {
            rg2.AddForce(Vector2.up * jumpForce);
            animator.SetBool("IsJumping", true);
            isGrounded = false;
        }

    }
    void EvaluateClick(InputAction.CallbackContext context)
    {

        // if empty space or player is clicked => jump
        // if waste or enemy is clicked => attack => check if player in range with something?  sword attack : shoot

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(playerInput.PlayerInput.ClickAndPoint.ReadValue<Vector2>()), Vector2.zero);
        clickedPos = playerInput.PlayerInput.ClickAndPoint.ReadValue<Vector2>();
        if (hit.collider != null)
        {

            Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
            if (hit.collider.gameObject.tag == "Player")
            {
                canMove = false;
                Jump();
            }
            else if (hit.collider.gameObject.tag == "Enemy" || hit.collider.gameObject.tag != "Waste")
            {
                canMove = false;
                if(hit.collider.gameObject.tag == "Enemy" && Vector2.Distance(transform.position, hit.transform.position) < 25f)
                {
                    StartCoroutine(ChangeSwordPos());
                }
                else
                {
                    BulletLaunch();
                    StartCoroutine(ChangeShootingAnim());
                }
               
            }
            else
            {
                canMove = true;
            }
        }
        else
        {
            canMove = true;
        }
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

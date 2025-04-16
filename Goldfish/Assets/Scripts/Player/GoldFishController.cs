using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class GoldFishController : MonoBehaviour
{
    [SerializeField] private float swimAmount = 70f;
    private Rigidbody2D rg2;
    Animator animator;
    PlayerControlls playerInput;
    void Awake()
    {
        rg2 = GetComponent<Rigidbody2D>();
        playerInput = new PlayerControlls();
        playerInput.PlayerInput.Tap.performed += Swim;
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
    }

    void Swim(InputAction.CallbackContext context)
    {
        rg2.velocity = Vector2.up * swimAmount; // to make swimming repeatable and consistent, work good with gravity 35
    }
}

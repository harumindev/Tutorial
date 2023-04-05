using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed;
    Rigidbody2D rb;

    Vector2 moveInput;

    public bool IsMoving { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // This method is called after Awake() and OnEnable() are called and before the first frame is displayed
    void Start()
    {
        
    }

    // This method is called every frame and is used to perform computations unrelated to physics.
    void Update()
    {
        
    }

    // This method is called at a fixed rate (usually 50 times per second) and is used to perform physics calculations for the object.
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context) 
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;
    }

}

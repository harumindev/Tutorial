using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 8f;

    Vector2 moveInput;

    public float CurrentMoveSpeed { get
        {
            if (IsMoving)
            {
                if (IsRunning)
                {
                    return runSpeed;
                } else
                {
                    return walkSpeed;
                }
            }
            else
            {
                //idle Speed = 0
                return 0;
            }
        } }
            
    [SerializeField]
    private bool _isMoving = false;

    public bool IsMoving { get
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;
            animator.SetBool("isMoving", value);
        }
    }

    [SerializeField]
    private bool _isRunning = false;

    public bool IsRunning
    {
        get
        {
            return _isRunning;
        }
        private set
        {
            _isRunning = value;
            animator.SetBool("isRunning", value);
        }
    }

    public bool _isFacingRight = true;
    public bool IsFacingRight
    {
        get { return _isFacingRight; }

        private set
        {
            // Flip only if value is new
            if (_isFacingRight != value)
            {
                // Flip the local scale to make the player face the opposite direction
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        }
    }

    Rigidbody2D rb;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
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
        rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context) 
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        SetFacingDirection(moveInput);

    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !IsFacingRight)
        {
            // Face the right
            IsFacingRight = true;
        } 
        else if(moveInput.x < 0 && IsFacingRight)
        {
            // Face the left
            IsFacingRight = false;
        } 
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsRunning = true;
        }
        else if (context.canceled)
        {
            IsRunning = false;
        }
    }

}

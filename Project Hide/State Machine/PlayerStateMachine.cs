using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// This is the context.
// Stores the presistent state data that is passed to the active Concrete states.
// Data is used for the their logic and switching between states.


public class PlayerStateMachine : MonoBehaviour
{
    private PlayerInputAction _playerInputAction;
    public Animator animator;
    public Rigidbody rb; // Not sure how to put this to a getter and setter so just made it public
    [SerializeField] CapsuleCollider _capsuleCollider;

    // Ground and Camera Controll
    [SerializeField] LayerMask _Ground;
    [SerializeField] private float _movementSpeed = 3f;
    [SerializeField] public Camera _playerCamera;
    [SerializeField] private float _maxSpeed = 3f;
    public Vector2 inputVector;  
    public Vector3 forceDirection;
    private bool _isMovementPressed = false;



    // Jumping
    [SerializeField] private float _jumpForce;
    //public bool _requireNewJump = false;
    private float _gravity;
    [SerializeField] float _fallMultiplier = 2f;
    bool _isJumpingPressed = false;
    float _initialJumpVelocity;
    [SerializeField] float _maxJumpHeight = 1f; // The height you want to reach  
    [SerializeField] float _maxJumpTime = 0.5f; // This is the time for the whole journey.
    bool _isJumping = false;

    // State Varibles
    PlayerBaseState _currentState;
    PlayerStateFactory _states;

    // Getter and Setter  (Cleaner ways to access member varibles in another class)
    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value;} }
    public bool IsJumpingPressed { get { return _isJumpingPressed; } set { _isJumpingPressed = value; } }
    public bool IsJumping { get { return _isJumping; } set { _isJumping = value;  } }

  
    public float MovementSpeed { get { return _movementSpeed; } set { _movementSpeed = value; } }

    public float MaxSpeed { get { return _maxSpeed; } set { _maxSpeed = value; } }

    public float JumpForce { get { return _jumpForce; } set { _jumpForce = value; } }
    public float InitialJumpVelocity { get { return _initialJumpVelocity; } set { _initialJumpVelocity = value; } }

    public float JumpingGravity { get { return _gravity; } set { _gravity = value; } }
    public float FallMultiplier { get { return _fallMultiplier; } set { _fallMultiplier = value; } }

    public float MaxJumpHeight { get { return _maxJumpHeight; }  set { _maxJumpHeight = value; } }

    public float MaxJumpTime { get { return _maxJumpTime; } set { _maxJumpTime = value; } }
    public bool IsMovementPressed { get { return _isMovementPressed; } set { _isMovementPressed = value; } }






    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        _playerInputAction = new PlayerInputAction();
        _capsuleCollider = this.GetComponent<CapsuleCollider>();

        // Set up States
        _states = new PlayerStateFactory(this);  // This refers to the PlayerStateMachine
        _currentState = _states.Grounded(); // Returns an instance of the Concrete Grouneded
        _currentState.EnterState(); // This Inovkes the Grounded EnterState
         
        // These are the PlayerCallBack
        // Player Movement (Have to DO THE CANCELED)
        _playerInputAction.Player.Movement.performed += DoMove;
        _playerInputAction.Player.Movement.canceled += DoMove;
        // Player Jump
        _playerInputAction.Player.Jump.performed += DoJump;
        _playerInputAction.Player.Jump.canceled += DoJump;

        SetJumpVaribles();
    }

    void SetJumpVaribles()
    {
        float timeToApex = _maxJumpTime / 2;
        _gravity = (-2 * _maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        _initialJumpVelocity = (2 * _maxJumpHeight) / timeToApex;
    }
    private void DoMove(InputAction.CallbackContext obj)
    {
        inputVector = obj.ReadValue<Vector2>();  // This is just the read the values for the Movement inputs
        _isMovementPressed = inputVector.x != 0 || inputVector.y != 0;

    }
    private void DoJump(InputAction.CallbackContext obj)
    {
        _isJumpingPressed = obj.ReadValueAsButton();  // True when pressed, false when released as we can .canceled above
   
    }


    private void Update()
    {
        _currentState.UpdateStates();
      
    }


    private void FixedUpdate()
    {
        _currentState.FixedUpdateStates();
        LookAt();
       
    }
 

    private void LookAt() // Turns the character to where you are look at.
    {
        Vector3 direction = rb.velocity;
        direction.y = 0f;

        if (inputVector.sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            rb.angularVelocity = Vector3.zero;
    }
    public bool IsGrounded()
    {
        //get the radius of the players capsule collider, and make it a tiny bit smaller than that
        float radius = _capsuleCollider.radius;
        //get the position (assuming its right at the bottom) and move it up by almost the whole radius
        Vector3 pos = transform.position + Vector3.up * (radius * 0.55f);
        //returns true if the sphere touches something on that layer
        if (Physics.CheckSphere(pos, radius, _Ground))
        {
           
            return true;

        }
        else
            return false;
    }

 
    private void OnEnable()
    {
        _playerInputAction.Player.Enable();
    }
    private void OnDisable()
    {
        _playerInputAction.Player.Disable();
    }



}

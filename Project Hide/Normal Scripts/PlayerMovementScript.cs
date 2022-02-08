using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    private PlayerInputAction playerInputAction;
    private Rigidbody rb;
    [SerializeField] CapsuleCollider capsuleCollider;

    [SerializeField] LayerMask Ground;

    [SerializeField] private float movementSpeed = 3f;
    //[SerializeField] private float jumpforce = 3f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float maxSpeed = 3f;

    private Vector2 inputVector;
    private Vector3 forceDirection;

    private float normalGravity = 0;
    // Jumping Varibles
    private float gravity;
    [SerializeField] float fallMultiplier = 2f;
    bool isJumpingPressed = false;
    
    float initialJumpVelocity;
    [SerializeField] float maxJumpHeight = 1f; // The height you want to reach  
    [SerializeField] float maxJumpTime = 0.5f; // This is the time for the whole journey.
    bool isJumping = false;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        playerInputAction = new PlayerInputAction();
        capsuleCollider = this.GetComponent<CapsuleCollider>();

        normalGravity = Physics.gravity.y;
        SetJumpVaribles();
    }

    private void OnEnable()
    {
        // Player Movement (Have to DO THE CANCELED)
        playerInputAction.Player.Movement.Enable();
        playerInputAction.Player.Movement.performed += DoMove;
        playerInputAction.Player.Movement.canceled += DoMove;
        // Player Jump
        playerInputAction.Player.Jump.Enable();
        playerInputAction.Player.Jump.performed += DoJump;
        playerInputAction.Player.Jump.canceled += DoJump;
    }

    void SetJumpVaribles()
    {
        float timeToApex = maxJumpTime / 2;
        gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }

    void HandleJump()
    {
        if (isJumpingPressed && IsGrounded() && !isJumping)
        {
            isJumping = true;
            forceDirection.y = initialJumpVelocity;

        }
        else if (!isJumpingPressed && isJumping && IsGrounded())
        {
            isJumping = false;
        }
    }
    private void DoMove(InputAction.CallbackContext obj)
    {
        inputVector = obj.ReadValue<Vector2>();  // This is just the read the values for the Movement inputs
    }
    private void DoJump(InputAction.CallbackContext obj)
    {
        isJumpingPressed = obj.ReadValueAsButton();  // True when pressed, false when released as we can .canceled above
    }



    private void FixedUpdate()
    {
        forceDirection += inputVector.x * GetCameraRight(playerCamera) * movementSpeed;
        forceDirection += inputVector.y * GetCameraForward(playerCamera) * movementSpeed;
        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;


        if (rb.velocity.y <= 0.0f && !IsGrounded() || !isJumpingPressed && !IsGrounded())
        {
            rb.useGravity = false;
            rb.velocity -= Vector3.down * gravity * fallMultiplier * Time.fixedDeltaTime;
          
        }

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;
        }

        LookAt();
        HandleJump();
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
    private Vector3 GetCameraForward(Camera playerCamera) //Turns regardless of camera orentation.
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera) //Turns regardless of camera orentation.
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }


    private bool IsGrounded()
    {
        //get the radius of the players capsule collider, and make it a tiny bit smaller than that
        float radius = capsuleCollider.radius;
        //get the position (assuming its right at the bottom) and move it up by almost the whole radius
        Vector3 pos = transform.position + Vector3.up * (radius * 0.55f);
        //returns true if the sphere touches something on that layer
        if (Physics.CheckSphere(pos, radius, Ground))
        {
            rb.useGravity = true;
            return true;

        }
        else
            return false;
    }





}


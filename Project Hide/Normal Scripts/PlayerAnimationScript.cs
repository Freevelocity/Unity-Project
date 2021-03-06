using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    [SerializeField] private PlayerMovementScript movementScript;
    private Animator animator;
    private Rigidbody rb;
    [SerializeField] private float A_maxSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      
        animator.SetFloat("Speed", rb.velocity.magnitude/A_maxSpeed);
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D rb;
    public CharacterController2D controller;
    public Animator animator;
    public float mvntSpeed = 200f;
    public float sprintMultiplier = 1.2f;
    public float groundedGravityScale = 5f;
    public float cutOffJumpForce = 5f;
    private float baseMvntSpeed;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Start() {
        baseMvntSpeed = mvntSpeed;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * mvntSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // jump check
        if (Input.GetButtonDown("Jump")) {

            jump = true;
            animator.SetBool("isJump", true);
        }
        // handle jump cutoff
        if (Input.GetButtonUp("Jump") && !controller.IsGrounded()) {
            if (rb.velocity.y > 0) { // If still ascending
                rb.AddForce(Vector2.down * cutOffJumpForce, ForceMode2D.Impulse);
            }
        
        }
        // crouching functionality
        if (Input.GetButtonDown("Crouch")) {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch")) {
            crouch = false;
        }

        // sprinting functionality
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
            mvntSpeed = baseMvntSpeed * sprintMultiplier;
        }
        else {
            mvntSpeed = baseMvntSpeed;
        }

        if (controller.IsGrounded() && !jump) {
            rb.gravityScale = groundedGravityScale;
        }
        else {
            rb.gravityScale = 1;
        }
    }
    public void onLanding() {

        animator.SetBool("isJump", false);
    }
    public void onCrouch(bool isCrouching) {
        
        animator.SetBool("isCrouch", isCrouching);

    }
    
    void FixedUpdate() {

        //Move Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;        
    }
}

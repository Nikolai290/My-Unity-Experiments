using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    public Rigidbody2D CharacterRb;
    public Collider2D GroundSensor;
    public Animator animator;


    public float SpeedRun = 700f;
    public float JumpForce = 4000f;
    public float Stopping = 1.5f;


    private bool isGoRight;
    private bool isGoLeft;
    private bool isGround;



    void Update() {

        if (Input.GetKey(KeyCode.A))
            isGoLeft = true;
        if (Input.GetKeyUp(KeyCode.A))
            isGoLeft = false;
        if (Input.GetKey(KeyCode.D))
            isGoRight = true;
        if (Input.GetKeyUp(KeyCode.D))
            isGoRight = false;


    }




    private void FixedUpdate() {
        isGround = GroundSensor.GetComponent<GroundSensor>().IsGrounded;

        AnimatorSets();
        if (isGround) {
            if (isGoRight) {
                CharacterRb.velocity = Vector2.right * SpeedRun * Time.fixedDeltaTime;
            }
            if (isGoLeft) {
                CharacterRb.velocity = Vector2.left * SpeedRun * Time.fixedDeltaTime;
            }
            if (!isGoLeft && !isGoRight)
                CharacterRb.velocity = Vector2.zero;
            if (Input.GetKeyDown(KeyCode.Space)) {
                CharacterRb.AddForce(Vector2.up * JumpForce);
            }
        }
    }

    private void AnimatorSets() {
        animator.SetBool("IsGround", isGround);
        animator.SetFloat("Speed", Mathf.Abs(CharacterRb.velocity.x));
    }
}

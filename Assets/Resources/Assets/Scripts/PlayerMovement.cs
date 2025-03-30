using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;

public class TopDownControls : MonoBehaviour
{

    //Declare Rigidbody 2D
    Rigidbody2D rb;
    SpriteRenderer sr;
    //Move Speed Multiplier
    public float moveSpeed = 10f;
    public Animator animator;
    public Vector2 movement;

    void Start()
    {
        //Get Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {

        if(movement.x < 0) sr.flipX = true;
        else if(movement.x >= 0) sr.flipX = false;
       
        

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

    private void OnMovement (InputValue value)
    {
        movement = value.Get<Vector2>();

        //Set Animation Parameters
        if (movement.x !=0 || movement.y !=0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);
            animator.SetBool("IsWalking", true);

        }else {
            animator.SetBool("IsWalking", false);
        }
        
    }
}

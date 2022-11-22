using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float movementspeed = 5f;

    public Rigidbody2D rb;

    private Vector2 movement;

    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x =Input.GetAxisRaw("Horizontal");
        movement.y =Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        
    }   

    private void FixedUpdate()
    {
        //Move
        rb.MovePosition(rb.position+ movement * (movementspeed * Time.deltaTime));
    }
}

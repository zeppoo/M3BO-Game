using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Jump Settings")]
    [SerializeField] float jumpTime;//Max tijd dat je spring knop kan gebruiken
    [SerializeField] int jumpPower;//kracht van sprong
    [SerializeField] float fallMultiplier;//Sneller laten vallen
    [SerializeField] float jumpMultiplier;//sneller omhoog gaan

    public Transform groundCheck;//selecteert welke groundcheck je gebruikt
    public LayerMask groundLayer;//Wat teld als de grond
    Vector2 vecGravity;//nieuwe vector locatie

    bool isJumping;
    float jumpCounter;
    bool doubleJump;

    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);//vector word aangemaakt
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        if(Input.GetButtonDown("Jump"))
            if (isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                //Er wordt een nieuwe locatie als doel gesteld. X is huidige horizontale snelheid. Y is kracht van jump
                isJumping = true;
                doubleJump = true;
                jumpCounter = 0;
            }
            else if (doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                doubleJump = false;
            }

        if(rb.velocity.y>0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if(jumpCounter>jumpTime) isJumping = false;

            rb.velocity += vecGravity * jumpMultiplier * Time.deltaTime;
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }
        
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.8f, 0.3f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }
}

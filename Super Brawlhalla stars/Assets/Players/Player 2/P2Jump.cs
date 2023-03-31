using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Jump : MonoBehaviour
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
    bool firstJump;
    bool doubleJump;

    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);//vector word aangemaakt
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    { 

        if(Input.GetKeyDown(KeyCode.UpArrow))
            if (firstJump == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                //Er wordt een nieuwe locatie als doel gesteld. X is huidige horizontale snelheid. Y is kracht van jump
                isJumping = true;
                firstJump = true;
                doubleJump = true;
                jumpCounter = 0;
            }
            else if (doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                doubleJump = false;
            }

        if(rb.velocity.y>0 && isJumping)//terwijl je spatiebalk ingedrukt hebt
        {
            jumpCounter += Time.deltaTime;//jumpCounter word opgeteld met Aantal tijd dat voorbij is
            if(jumpCounter>jumpTime) isJumping = false;//zodra jumpcounter groter word dan de maximale jumptijd kom je niet meer hoger

            rb.velocity += vecGravity * jumpMultiplier * Time.deltaTime;//Velocity word  
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isJumping = false;//when you release jump button
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;// if velocity is negative, activate fallMoultiplier
        }

        if (isJumping == false && isGrounded())
        {
            firstJump = false;
        }
        
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.8f, 0.3f), CapsuleDirection2D.Horizontal, 0, groundLayer);//checks if invisible capsule collider is on the groundlayer
    }
}

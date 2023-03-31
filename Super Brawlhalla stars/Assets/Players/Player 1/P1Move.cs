using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Move : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 10;
    public float rbacceleration = 5;
    public float rbdecceleration = 5;
    private bool facingRight = true;
    public float velPower;
    public int moveInput = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveInput = 1;
            FacingRight = true;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            moveInput = -1;
            FacingRight = false;
        }

        if (Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.A) == false)
        {
            moveInput = 0;
        }
     

        //calculate the direction we want to move in and our desired velocity
        float targetSpeed = moveInput * moveSpeed;
        //calculate difference between current velocity and desired velocity
        float speedDif = targetSpeed - rb.velocity.x;
        //Calculate if our moveInput is 0 it will de accelerate, anything higher than 00.1 will make us accelerate
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? rbacceleration : rbdecceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
        rb.AddForce(movement * Vector2.right);
    }

    public bool FacingRight
        {
            get {return facingRight;}
            set
            {
                if (facingRight != value)
                {
                    facingRight = value;
                    transform.Rotate(0,180,0);
                }
            }
        }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerrespawn : MonoBehaviour
{
    public Transform checkpoint;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // If the Collider2D component is enabled on the collided object
        if (coll.collider.tag == "Deathborder")
        {
            // Disables the Collider2D component
            transform.position = new Vector3(checkpoint.position.x, checkpoint.position.y, checkpoint.position.z);
            rb.velocity = new Vector3(0,0,0);
            
        }
    }
}

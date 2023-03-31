using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerrespawn : MonoBehaviour
{
    public Transform checkpoint;
    // Start is called before the first frame update
    void Start()
    {
        
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
        }
    }
}

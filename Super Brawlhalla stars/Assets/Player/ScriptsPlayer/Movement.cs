using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private bool facingRight = true;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            FacingRight = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.right * -moveSpeed * Time.deltaTime;
            FacingRight = false;
        }
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

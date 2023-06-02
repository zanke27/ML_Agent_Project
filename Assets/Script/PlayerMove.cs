using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0) * speed;
    }

    /*
             if (Input.GetKey(KeyCode.A))
        {
            if (rb.velocity.x > 0)
                rb.velocity = Vector3.zero;

            
            rb.AddForce(new Vector3(-10, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.x < 0)
                rb.velocity = Vector3.zero;

            rb.AddForce(new Vector3(10, 0, 0));
        } 
     */
}

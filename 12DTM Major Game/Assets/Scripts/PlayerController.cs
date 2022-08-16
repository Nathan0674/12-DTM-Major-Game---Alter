using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 10.0f;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();  
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if(vertical != 0)
        {
            body.velocity = new Vector2(body.velocity.x, vertical * runSpeed);
        }
        body.velocity = new Vector2(horizontal * runSpeed, body.velocity.y);
    }
}
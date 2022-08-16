using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    public SpriteRenderer spriteRenderer;
    public Sprite playerDark;
    public Sprite playerLight;
    public float horizontal;
    public float vertical;
    public int swapNumber;

    public float runSpeed = 10.0f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            spriteRenderer.flipX = false;
        }
        
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
        } 

        if(Input.GetKeyDown("x"))
        {
            swapNumber += 1;
            
            if(swapNumber%2==0)
            {
                spriteRenderer.sprite = playerDark; 
            }
            else
            {
                spriteRenderer.sprite = playerLight; 
            }
        }
    }
}
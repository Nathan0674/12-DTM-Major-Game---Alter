using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    private BoxCollider2D bc;
    private SpriteRenderer spriteRenderer;
    public LayerMask groundLayer;
    public Sprite playerDark;
    public Sprite playerLight;
    public GameObject groundCheck;

    public float horizontal;
    public float vertical;
    public int swapNumber;
    public float runSpeed = 6.0f;
    public float jumpPower = 15.0f;
    private bool isGrounded;
    public int playerHitPoints = 50;

    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();  
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.transform.position, new Vector2(bc.bounds.size.x - 0.1f, 0.3f), 0f, groundLayer);
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if(vertical != 0 && isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, vertical * jumpPower);
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
                spriteRenderer.sprite = playerLight; 
            }
            else
            {
                spriteRenderer.sprite = playerDark; 
            }
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "EnemyCollision")
        {
            playerHitPoints -= 5;
            Debug.Log(playerHitPoints);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;
    private BoxCollider2D bc;
    private SpriteRenderer spriteRenderer;
    public LayerMask groundLayer;
    public Sprite playerDark;
    public Sprite playerLight;
    public GameObject groundCheck;
    public GameObject PlayerBullet;
    public GameObject spawnPoint;
    public Vector3 shootDirection;
    private GameObject powerUpManager;

    public float horizontal;
    public float vertical;
    public int swapNumber;
    public float runSpeed;
    public float jumpPower = 15.0f;
    private bool isGrounded;
    public bool movingLeft;
    public bool movingRight;
    public int playerHitPoints = 50;
    private float time = 0.2f;
    private bool runSpeedBuffSet = false;

    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();  
        powerUpManager = GameObject.Find("PowerUpManager");
    }

    void Update()
    {
        if (powerUpManager.GetComponent<PowerUpManager>().increasePlayerSpeed == true && runSpeedBuffSet == false)
        {
            runSpeed = runSpeed += 4;
            runSpeedBuffSet = true;
        }

        shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection-transform.position;

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
            movingRight = true;
            spriteRenderer.flipX = false;
        }
        
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            movingLeft = true;
            spriteRenderer.flipX = true;
        } 
        else 
        {
            movingLeft = false;
            movingRight = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(PlayerBullet, new Vector2(transform.position.x, transform.position.y + 0.7f), Quaternion.identity);

            if (powerUpManager.GetComponent<PowerUpManager>().doubleBullets == true) 
            {
                StartCoroutine(DelayedShot(time));
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            gameObject.transform.position = spawnPoint.transform.position;
        }

        if (playerHitPoints <= 0) 
        {
            PlayerDeath();
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "EnemyCollision" || col.gameObject.tag == "EnemyBullet")
        {
            playerHitPoints -= 5;
        }
    }

    private void PlayerDeath()
    {
        LevelManager.instance.GameOver();
        gameObject.SetActive(false);
    }

    IEnumerator DelayedShot(float time)
    {
        yield return new WaitForSeconds(time);
    
        Instantiate(PlayerBullet, new Vector2(transform.position.x, transform.position.y + 0.7f), Quaternion.identity);
    }
}
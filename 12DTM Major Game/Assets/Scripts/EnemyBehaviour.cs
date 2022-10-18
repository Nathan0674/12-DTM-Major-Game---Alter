using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float enemySpeed;
    public float enemyJumpPower = 10.0f;
    public bool activeState;

    private Rigidbody2D rb2DEnemy;
    private SpriteRenderer enemySpriteRenderer;
    private BoxCollider2D enemyBoxCollider;
    public float enemyDirection;
    public LayerMask groundLayer;
    public LayerMask playerLayer;
    private GameObject Player;
    public GameObject EnemyBullet;
    public bool IsAvailable = true;
    public float CooldownDuration = 0.3f;
    private float enemyHitPoints = 30;

    // Start is called before the first frame update
    void Start()
    {
        enemyDirection = -1;
        activeState = false;

        Player = GameObject.Find("Player");

        enemyBoxCollider = GetComponent<BoxCollider2D>();
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
        rb2DEnemy = GetComponent<Rigidbody2D>();  

        InvokeRepeating("EnemyDirectionSwap", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 1.0f), (Vector2.right * enemyDirection), 0.5f, groundLayer);
        //Debug.DrawRay(new Vector2 (transform.position.x + (0.5f * enemyDirection), transform.position.y - 1.0f), (Vector2.right * enemyDirection), Color.green);
        if (hit == true)
        {
            rb2DEnemy.velocity = new Vector2(rb2DEnemy.velocity.x, 1.0f * enemyJumpPower);
            //Debug.Log("Jumping");
        }

        if (activeState == false)
        {
            rb2DEnemy.velocity = new Vector2(enemySpeed * enemyDirection, rb2DEnemy.velocity.y);

            if (enemyDirection > 0)
            {
                enemySpriteRenderer.flipX = false;
            }
            
            else if (enemyDirection < 0)
            {
                enemySpriteRenderer.flipX = true;
            } 
        }

        if (activeState == true)
        {
            enemyJumpPower = 10;
            if (Player.transform.position.x > (gameObject.transform.position.x + 0.5f))
            {
                enemyDirection = 1;
                rb2DEnemy.velocity = new Vector2(enemySpeed * enemyDirection, rb2DEnemy.velocity.y);
            }
            if (Player.transform.position.x < (gameObject.transform.position.x - 0.5f))
            {
                enemyDirection = -1;
                rb2DEnemy.velocity = new Vector2(enemySpeed * enemyDirection, rb2DEnemy.velocity.y);
            }
            if (enemyDirection > 0)
            {
                enemySpriteRenderer.flipX = false;
            }
            
            else if (enemyDirection < 0)
            {
                enemySpriteRenderer.flipX = true;
            } 
        }
        else
        {
            enemyJumpPower = 5;
        }

        RaycastHit2D shoot = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 0.6f), (Vector2.right * enemyDirection), 6.0f, playerLayer);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + 0.6f), Vector2.right * enemyDirection * 6.0f, Color.green);
    
        if (shoot == true)
        {
            UseAbility();
        }
    }

    void UseAbility()
    {
        if (IsAvailable == false)
        {
            return;
        }

        Instantiate(EnemyBullet, new Vector2(transform.position.x, transform.position.y + 0.7f), Quaternion.identity);
        // Debug.Log("Shot Fired");

        StartCoroutine(StartCooldown());
    }

    public IEnumerator StartCooldown()
    {
        IsAvailable = false;
        yield return new WaitForSeconds(CooldownDuration);
        IsAvailable = true;
    }

    void EnemyDirectionSwap()
    {
        enemyDirection = enemyDirection * -1f;
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "PlayerBullet")
        {
            enemyHitPoints = enemyHitPoints - 1;
            Debug.Log(enemyHitPoints);
            if (enemyHitPoints <= 0) 
            {
                Destroy(gameObject);
                Debug.Log("Enemy Killed");
            }
        }
    }
}

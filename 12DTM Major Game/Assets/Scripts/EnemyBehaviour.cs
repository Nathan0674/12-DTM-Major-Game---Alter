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
    private float enemyDirection;
    public LayerMask groundLayer;
    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        enemyDirection = -1;
        activeState = false;

        enemyBoxCollider = GetComponent<BoxCollider2D>();
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
        rb2DEnemy = GetComponent<Rigidbody2D>();  

        InvokeRepeating("EnemyDirectionSwap", 0.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (Vector2.right * enemyDirection), 1.0f, groundLayer);
        Debug.DrawRay(new Vector2 (transform.position.x + (0.5f * enemyDirection), transform.position.y), (Vector2.right * enemyDirection), Color.green);
        if (hit == true)
        {
            rb2DEnemy.velocity = new Vector2(rb2DEnemy.velocity.x, 1.0f * enemyJumpPower);
            Debug.Log("Jumping");
        }
        else{
            Debug.Log("Child");
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
            if (Player.position.x > (gameObject.transform.position.x + 0.5f))
            {
                enemyDirection = 1;
                rb2DEnemy.velocity = new Vector2(enemySpeed * enemyDirection, rb2DEnemy.velocity.y);
            }
            if (Player.position.x < (gameObject.transform.position.x - 0.5f))
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
    }

    void EnemyDirectionSwap()
    {
        enemyDirection = enemyDirection * -1f;
    }
}

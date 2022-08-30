using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float enemySpeed;
    public bool activeState;

    Rigidbody2D rb2DEnemy;
    private SpriteRenderer enemySpriteRenderer;
    private BoxCollider2D enemyBoxCollider;
    private float enemyDirection;
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
            if (Player.position.x > gameObject.transform.position.x)
            {
                enemyDirection = 1;
                rb2DEnemy.velocity = new Vector2(enemySpeed * enemyDirection, rb2DEnemy.velocity.y);
            }
            if (Player.position.x < gameObject.transform.position.x)
            {
                enemyDirection = -1;
                rb2DEnemy.velocity = new Vector2(enemySpeed * enemyDirection, rb2DEnemy.velocity.y);
            }
        }
    }

    void EnemyDirectionSwap()
    {
        enemyDirection = enemyDirection * -1f;
        Debug.Log(enemyDirection);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float enemySpeed;
    Rigidbody2D rb2DEnemy;
    private SpriteRenderer enemySpriteRenderer;
    private BoxCollider2D enemyBoxCollider;
    private float enemyDirection;

    // Start is called before the first frame update
    void Start()
    {
        enemyDirection = -1;

        enemyBoxCollider = GetComponent<BoxCollider2D>();
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
        rb2DEnemy = GetComponent<Rigidbody2D>();  

        InvokeRepeating("EnemyDirectionSwap", 0.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
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

    void EnemyDirectionSwap()
    {
        enemyDirection = enemyDirection * -1f;
        Debug.Log(enemyDirection);
    }
}

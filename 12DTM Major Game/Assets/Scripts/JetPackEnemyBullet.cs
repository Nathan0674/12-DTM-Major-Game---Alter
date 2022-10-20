using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackEnemyBullet : MonoBehaviour
{
    private GameObject enemy;
    private Transform target;
    private GameObject player;
    public float speed;
    public float bulletLifetime;
    private int bulletDirection;
    private SpriteRenderer bulletSpriteRenderer;

    float bulletLifetimeTimer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        target = player.transform;
        enemy = GameObject.Find("Enemy");
        bulletLifetimeTimer = bulletLifetime;
        bulletSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        bulletLifetimeTimer -= Time.deltaTime;
        if (bulletLifetimeTimer <= 0f)
        {
            Destroy(gameObject);
        }
        if (player.transform.position.x > (gameObject.transform.position.x + 0.5f)) 
        {
            bulletDirection = 1;
        }
        if (player.transform.position.x < (gameObject.transform.position.x - 0.5f)) 
        {
            bulletDirection = -1;
        }
        if (bulletDirection > 0)
        {
            bulletSpriteRenderer.flipX = false;
        }
        else if (bulletDirection < 0)
        {
            bulletSpriteRenderer.flipX = true;
        } 
    }
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag != "Enemy" && col.gameObject.tag != "EnemyCollision" && col.gameObject.tag != "EnemySight" && col.gameObject.tag != "SpiderSight" && col.gameObject.tag != "Background")
        {
            Destroy(gameObject);
        }
    }
}

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

    float bulletLifetimeTimer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        target = player.transform;
        enemy = GameObject.Find("Enemy");
        bulletLifetimeTimer = bulletLifetime;
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
    }
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag != "Enemy" && col.gameObject.tag != "EnemyCollision" && col.gameObject.tag != "EnemySight" && col.gameObject.tag != "SpiderSight" && col.gameObject.tag != "Background")
        {
            Destroy(gameObject);
        }
    }
}

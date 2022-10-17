using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackEnemyBullet : MonoBehaviour
{
    private GameObject enemy;
    private Transform target;
    private GameObject player;
    public float speed;
    private float bulletDirection;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        target = player.transform;
        enemy = GameObject.Find("Enemy");
        bulletDirection = enemy.gameObject.GetComponent<EnemyBehaviour>().enemyDirection;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}

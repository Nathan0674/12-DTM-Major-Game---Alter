using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    private GameObject enemy;
    private GameObject player;
    private Rigidbody2D bulletRb2D;
    public float speed;

    bool velocitySet;
    

    // Start is called before the first frame update
    void Start()
    {
        bulletRb2D = GetComponent<Rigidbody2D>();
        
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
        velocitySet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (velocitySet == false) 
        {
            bulletRb2D.velocity = new Vector2(player.gameObject.GetComponent<PlayerController>().shootDirection.x * speed, player.gameObject.GetComponent<PlayerController>().shootDirection.y * speed);
        }
        velocitySet = true;

        if (Vector2.Distance(gameObject.transform.position, player.transform.position) >= 8) 
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag != "Player" && col.gameObject.tag != "EnemyCollision" && col.gameObject.tag != "EnemySight" && col.gameObject.tag != "SpiderSight" && col.gameObject.tag != "Background" && col.gameObject.tag != "PlayerBullet")
        {
            Destroy(gameObject);
        }
    }
}

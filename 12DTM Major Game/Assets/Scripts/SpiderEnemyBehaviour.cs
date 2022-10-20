using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemyBehaviour : MonoBehaviour
{
    private float spiderSpeed = 1;
    public bool activeState;
    private float spiderHitPoints = 50;

    private Rigidbody2D rb2DSpider;
    private SpriteRenderer spiderSpriteRenderer;
    private BoxCollider2D spiderBoxCollider;
    public float spiderDirection;
    public LayerMask groundLayer;
    public LayerMask playerLayer;
    public GameObject Player;
    public Transform playerPos;
    private GameObject barrier;

    // Start is called before the first frame update
    void Start()
    {
        spiderDirection = -1;
        activeState = false;

        barrier = GameObject.Find("Barrier");
        Player = GameObject.Find("Player");
        playerPos = Player.transform;

        spiderBoxCollider = GetComponent<BoxCollider2D>();
        spiderSpriteRenderer = GetComponent<SpriteRenderer>();
        rb2DSpider = GetComponent<Rigidbody2D>();  

        InvokeRepeating("SpiderDirectionSwap", 0.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 1.0f), (Vector2.right * spiderDirection), 0.5f, groundLayer);
        //Debug.DrawRay(new Vector2 (transform.position.x + (0.5f * spiderDirection), transform.position.y - 1.0f), (Vector2.right * spiderDirection), Color.green);
        if (hit == true)
        {
            return;
        }

        if (activeState == false)
        {
            spiderSpeed = 1;
            rb2DSpider.velocity = new Vector2(spiderSpeed * spiderDirection, rb2DSpider.velocity.y);

            if (spiderDirection > 0)
            {
                spiderSpriteRenderer.flipX = false;
            }
            
            else if (spiderDirection < 0)
            {
                spiderSpriteRenderer.flipX = true;
            } 
        }

        if (activeState == true)
        {
            spiderSpeed = 3;
            if (playerPos.position.x > (gameObject.transform.position.x + 0.5f))
            {
                spiderDirection = 1;
                rb2DSpider.velocity = new Vector2(spiderSpeed * spiderDirection, rb2DSpider.velocity.y);
            }
            if (playerPos.position.x < (gameObject.transform.position.x - 0.5f))
            {
                spiderDirection = -1;
                rb2DSpider.velocity = new Vector2(spiderSpeed * spiderDirection, rb2DSpider.velocity.y);
            }
        }
    }

    void SpiderDirectionSwap()
    {
        spiderDirection = spiderDirection * -1f;
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "PlayerBullet")
        {
            spiderHitPoints = spiderHitPoints - 0.5f;
            Debug.Log(spiderHitPoints);
            if (spiderHitPoints <= 0) 
            {
                barrier.gameObject.GetComponent<clearManager>().enemiesKilled += 1;
                Debug.Log(barrier.gameObject.GetComponent<clearManager>().enemiesKilled);
                Destroy(gameObject);
            }
        }
    }
}

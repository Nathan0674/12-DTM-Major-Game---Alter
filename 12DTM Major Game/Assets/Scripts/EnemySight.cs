using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    Rigidbody2D rb2Sight;
    public GameObject enemy;
    public Transform EnemyDetectionRadius;
    public Transform Enemy;

    // Start is called before the first frame update
    void Start()
    {
        rb2Sight = GetComponent<Rigidbody2D>();
        enemy = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        EnemyDetectionRadius.position = Enemy.position;
    }

    void OnTriggerStay2D (Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Enemy.gameObject.GetComponent<EnemyBehaviour>().activeState = true;
            Debug.Log("Enemy Active");
        }
    }
}

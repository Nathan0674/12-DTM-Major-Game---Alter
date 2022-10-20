using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public GameObject enemy;
    public Transform EnemyDetectionRadius;
    public Transform Enemy;

    // Start is called before the first frame update
    void Start()
    {
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
        }
    }
    void OnTriggerExit2D (Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Enemy.gameObject.GetComponent<EnemyBehaviour>().activeState = false;
        }
    }
}

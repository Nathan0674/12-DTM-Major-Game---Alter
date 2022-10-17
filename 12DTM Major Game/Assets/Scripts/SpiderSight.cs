using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSight : MonoBehaviour
{
    public GameObject spider;
    public Transform SpiderDetectionRadius;
    public Transform Spider;

    // Start is called before the first frame update
    void Start()
    {
        spider = GameObject.Find("SpiderEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        SpiderDetectionRadius.position = Spider.position;
    }

    void OnTriggerStay2D (Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            spider.gameObject.GetComponent<SpiderEnemyBehaviour>().activeState = true;
        }
    }
    void OnTriggerExit2D (Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            spider.gameObject.GetComponent<SpiderEnemyBehaviour>().activeState = false;
        }
    }
}

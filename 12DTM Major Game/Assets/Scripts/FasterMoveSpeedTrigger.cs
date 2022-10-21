using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterMoveSpeedTrigger : MonoBehaviour
{
    private GameObject player;
    private GameObject powerUpManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        powerUpManager = GameObject.Find("PowerUpManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            powerUpManager.GetComponent<PowerUpManager>().increasePlayerSpeed = true;
            Destroy(gameObject);
        }
    }
}

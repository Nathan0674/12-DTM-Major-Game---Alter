using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private GameObject player;
    private int playerHealth;
    public Text playerHealthText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = player.GetComponent<PlayerController>().playerHitPoints;
        playerHealthText.text = playerHealth.ToString();
    }
}

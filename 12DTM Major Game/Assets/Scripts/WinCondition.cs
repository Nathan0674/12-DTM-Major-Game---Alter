using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject winPanel;
    private GameObject instructionPanel;

    // Start is called before the first frame update
    void Start()
    {
        winPanel = GameObject.Find("WinScreen");
        instructionPanel = GameObject.Find("StartScreen");
        winPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("awa awa");;
            winPanel.SetActive(true);
            instructionPanel.GetComponent<InstructionPannelToggle>().gameActive = false;
        }
    }
}

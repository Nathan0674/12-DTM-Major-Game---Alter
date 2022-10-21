using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionPannelToggle : MonoBehaviour
{
    public GameObject instructionPannel;
    public bool gameActive;
    // Start is called before the first frame update
    void Start()
    {
        instructionPannel = GameObject.Find("StartScreen");
        gameActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            instructionPannel.SetActive(!instructionPannel.activeSelf);
            gameActive = true;
        }
    }
}

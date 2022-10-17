using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Enemy, new Vector3(10f, 5f), Quaternion.identity);
        Debug.Log("Spawned");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

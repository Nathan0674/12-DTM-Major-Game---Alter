using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject SpiderEnemy;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Enemy, new Vector3(10f, 5f), Quaternion.identity);
        Instantiate(Enemy, new Vector3(18.3f, -3f), Quaternion.identity);

        Instantiate(Enemy, new Vector3(46.3f, -4f), Quaternion.identity);
        Instantiate(Enemy, new Vector3(62.5f, 3.5f), Quaternion.identity);
        Instantiate(SpiderEnemy, new Vector3(56f, -7f), Quaternion.identity);
        Instantiate(SpiderEnemy, new Vector3(87f, -4f), Quaternion.identity);

        Instantiate(Enemy, new Vector3(97f, 1f), Quaternion.identity);
        Instantiate(Enemy, new Vector3(100f, -8.5f), Quaternion.identity);
        Instantiate(Enemy, new Vector3(83f, -14f), Quaternion.identity);
        Instantiate(Enemy, new Vector3(86f, -14f), Quaternion.identity);
        Instantiate(Enemy, new Vector3(107f, -17.5f), Quaternion.identity);
        Instantiate(SpiderEnemy, new Vector3(95f, -19.5f), Quaternion.identity);
        Debug.Log("Spawning Finished");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

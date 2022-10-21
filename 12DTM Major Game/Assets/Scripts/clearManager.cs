using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearManager : MonoBehaviour
{
    public int enemiesKilled;
    public bool roomOneClear;
    public bool roomTwoClear;
    public bool roomThreeClear;
    private GameObject barrier;
    private Transform barrierTransform;
    private GameObject spawnPoint;
    private Transform spawnPointTransform;

    // Start is called before the first frame update
    void Start()
    {
        barrier = GameObject.Find("Barrier");
        spawnPoint = GameObject.Find("SpawnPoint");

        enemiesKilled = 0;
        barrierTransform = barrier.transform;
        barrier.transform.position = new Vector2(32.01f, 0.69f);
        spawnPointTransform = spawnPoint.transform;
        spawnPoint.transform.position = new Vector2(-4.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesKilled >= 3 && enemiesKilled <7) 
        {
            roomOneClear = true;
            barrier.transform.position = new Vector2(77f, 8f);
            spawnPoint.transform.position = new Vector2(32.01f, 0.69f);
        }
        else if (enemiesKilled >= 7 && enemiesKilled <13)
        {
            roomTwoClear = true;
            barrier.transform.position = new Vector2(115f, -14f);
            spawnPoint.transform.position = new Vector2(77f, 8f);
        }
        else if (enemiesKilled >= 13) 
        {
            roomThreeClear = true;
            barrier.transform.position = new Vector2(115f, -100f);
            spawnPoint.transform.position = new Vector2(118f, -14f);
        }

    }
}

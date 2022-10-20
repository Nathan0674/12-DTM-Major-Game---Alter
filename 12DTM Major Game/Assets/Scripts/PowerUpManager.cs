using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public bool doubleBullets;
    public bool increasePlayerSpeed;
    public bool increaseBulletDamage;
    private bool activeSet = false;

    private GameObject barrier;
    private GameObject bulletPowerUp;
    // Start is called before the first frame update
    void Start()
    {
        barrier = GameObject.Find("Barrier");
        bulletPowerUp = GameObject.Find("2xBulletPowerUp");

        bulletPowerUp.SetActive(false);
        doubleBullets = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (barrier.GetComponent<clearManager>().roomOneClear == true && activeSet == false) 
        {
            bulletPowerUp.SetActive(true);
            activeSet = true;
        }
    }
}

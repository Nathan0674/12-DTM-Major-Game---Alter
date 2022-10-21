using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public bool doubleBullets;
    public bool increasePlayerSpeed;
    public bool increaseBulletDamage;
    private bool activeSet = false;
    private bool activeSetTwo = false;
    private bool activeSetThree = false;

    private GameObject barrier;
    private GameObject bulletPowerUp;
    private GameObject speedBuff;
    private GameObject damageBuff;
    // Start is called before the first frame update
    void Start()
    {
        barrier = GameObject.Find("Barrier");
        bulletPowerUp = GameObject.Find("2xBulletPowerUp");
        speedBuff = GameObject.Find("speedPowerUp");
        damageBuff = GameObject.Find("bulletDamagePowerUp");

        bulletPowerUp.SetActive(false);
        doubleBullets = false;
        speedBuff.SetActive(false);
        increasePlayerSpeed = false;
        damageBuff.SetActive(false);
        increaseBulletDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (barrier.GetComponent<clearManager>().roomOneClear == true && activeSet == false) 
        {
            bulletPowerUp.SetActive(true);
            activeSet = true;
        }
        if (barrier.GetComponent<clearManager>().roomTwoClear == true && activeSetTwo == false) 
        {
            speedBuff.SetActive(true);
            activeSetTwo = true;
        }
        if (barrier.GetComponent<clearManager>().roomThreeClear == true && activeSetThree == false) 
        {
            damageBuff.SetActive(true);
            activeSetThree = true;
        }
    }
}

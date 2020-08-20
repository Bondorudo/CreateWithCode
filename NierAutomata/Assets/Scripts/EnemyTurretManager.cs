using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretManager : MonoBehaviour
{
    private Rigidbody enemyRb;
    private PlayerController thePlayer;
    public GameObject enemy;
    public GunController theGun;
    
    public float damping = 0;

    public int health = 3;
    private int currentHealth;

    public bool canShoot = false;

    Vector3 offSet = new Vector3(0, 0, 1);


    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();

        //set current health to be equal to starting health
        currentHealth = health;
    }

    void Update()
    {
        //Enemy rotates to look at the player
        var rotation = Quaternion.LookRotation(thePlayer.transform.position - enemy.transform.position);
        enemy.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);


        //Destroy enemy object when its health is 0
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }



        //Enemy can fire their gun when canShoot is true
        if (canShoot == true)
        {
            theGun.isFiring = true;
        }
    }
    
    //Enemy takes damage
    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }
}
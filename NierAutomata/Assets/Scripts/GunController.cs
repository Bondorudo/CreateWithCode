using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public BulletController bullet;
    public BulletController bullet2;
    public Transform firePoint;

    public float bulletSpeed;
    public float coolDownDefault = 0.1f;
    public float changeBulletTimer;
    float coolDown = 0;
    

    public bool isFiring = false;
    public bool changeProjectile = false;
    public bool isPlayer;
    private bool isEnemy;

    public bool IsEnemy { get => isEnemy; set => isEnemy = value; }

    private void Awake()
    {
        InvokeRepeating("Switch", 0, changeBulletTimer);
    }

    void Switch()
    {
        changeProjectile = !changeProjectile;
    }

    public void Update()
    {
        //is player
        if (isPlayer == true)
        {
            //A new projectile can be shot once coolDown reaches coolDownDefault
            coolDown += Time.deltaTime;
            if (isFiring && coolDown > coolDownDefault)
            {

                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                newBullet.speed = bulletSpeed;
                coolDown = 0;
            }
        }
        //is enemy
        if (IsEnemy == true)
        {
            //A new projectile can be shot once coolDown reaches coolDownDefault
            coolDown += Time.deltaTime;
            if (isFiring && coolDown > coolDownDefault)
            {
                if (changeProjectile == true)
                {
                    BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                    newBullet.speed = bulletSpeed;
                    coolDown = 0;
                }
                if (changeProjectile == false)
                {
                    BulletController newBullet = Instantiate(bullet2, firePoint.position, firePoint.rotation) as BulletController;
                    newBullet.speed = bulletSpeed;
                    coolDown = 0;
                }
            }
        }
        
    }
}
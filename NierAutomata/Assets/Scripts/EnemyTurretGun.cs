using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretGun : MonoBehaviour
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

    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    private Vector2 bulletMoveDirection;


    private void Awake()
    {
        InvokeRepeating("Switch", 0, changeBulletTimer);
    }

    void Switch()
    {
        changeProjectile = !changeProjectile;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 2f);
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            newBullet.speed = bulletSpeed;
            coolDown = 0;

            angle += angleStep;
        }
    }
}

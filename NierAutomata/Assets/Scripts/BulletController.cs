using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public float destroyBullet = 4;

    public int damageToGive = 1;


    
    void Update()
    {
        //cotrol projectile movement
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, destroyBullet);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Player" && gameObject.tag == "Purple")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Player" && gameObject.tag == "Orange")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Bullet" && gameObject.tag == "Orange")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Debug.Log("Bullets collided");
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy" && gameObject.tag == "Bullet")
        {
            collision.gameObject.GetComponent<EnemyManager>().HurtEnemy(damageToGive);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Bullet" && gameObject.tag == "Orange")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Debug.Log("Bullets collided");
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    private Renderer rend;
    public GameManager gameManager;

    public float flashLength;
    private float flashCounter;

    public int startingHealth;
    public int currentHealth;

    private Color storedColor;
    

    void Start()
    {
        currentHealth = startingHealth;
        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");
    }
    
    void Update()
    {
        //Game over happens if player health is equal to 0
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            gameManager.GameOver();
        }
        //Player color is restored to normal
        if (flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                rend.material.SetColor("_Color", storedColor);
            }
        }

        gameManager.healthText.text = "Health: " + currentHealth;
    }

    //When player is hurt they lose health and their color turns red
    public void HurtPlayer(int damageAmount)
    {
        currentHealth -= damageAmount;
        flashCounter = flashLength;
        rend.material.SetColor("_Color", Color.red);
    }
}

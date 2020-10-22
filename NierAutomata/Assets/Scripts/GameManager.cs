using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI gameOverText;
    public Button startButton;
    public Button restartButton;
    public PlayerController playerControl;
    public EnemyManager enemyManager;
    public GameObject enemyPrefab;

    private float spawnRange = 14f;
    
    private int enemyCount;
    private int waveNumber = 0;
    private int wave;

    private bool isGameActive;

    
    private void Start()
    {
        Time.timeScale = 0;
    }

    public void GameStart()
    {
        isGameActive = true;
        Time.timeScale = 1;

        //activate and deactivate certain UI elements at start of game
        startButton.gameObject.SetActive(false);
        titleText.gameObject.SetActive(false);
        waveText.gameObject.SetActive(true);
        healthText.gameObject.SetActive(true);

        wave = 0;
    }
    
    void Update()
    {
        if(isGameActive == true)
        {
            //When there are no enemies increase enemy- and wave count by 1 for the next wave
            enemyCount = FindObjectsOfType<EnemyManager>().Length;

            if (enemyCount == 0)
            {
                waveNumber++;
                SpawnEnemyWave(waveNumber);
                UpdateWave(1);
            }
        }
    }

    //Show wave count
    public void UpdateWave(int waveToAdd)
    {
        wave += waveToAdd;
        waveText.text = "Wave: " + wave;
    }

    //Game is over
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
        Time.timeScale = 0;
    }

    //Restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    //Calculates how manny enemies are to be spawned
    public void SpawnEnemyWave(int enemiesToSpawn)
    {

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);

        }
    }

    //Gives an enemy a random position to spawn at
    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0.5f, spawnPosZ);

        return randomPos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{     
    public static bool stopGame = false;
    public Transform player;
    public Transform wave;
    private Vector3 playerStartPos;
    private Vector3 waveStartPos;
    public int health = 3;
    public GameObject gameOverText;
    public GameObject mysteryShipPrefab;
    public float minSpawnTime = 4f;
    public float maxSpawnTime = 9f;
    public float initialDelay = 3f;

    void Start()
    {
        playerStartPos = player.position;
        waveStartPos = wave.position;
        StartCoroutine(SpawnMysteryShip());
        gameOverText.SetActive(false);
    }

    private IEnumerator SpawnMysteryShip()
    {
        yield return new WaitForSeconds(initialDelay);

        while (true)
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            Vector3 spawnPosition = new Vector3(Random.Range(-7f, 7f), 6f, 0f);
            Instantiate(mysteryShipPrefab, spawnPosition, Quaternion.identity);
        }
    }

    public void Reset()
    {
        stopGame = true;

        if (health > 0)
        {
            player.position = playerStartPos;
            wave.position = waveStartPos;
            health--;
            GameObject.FindObjectOfType<Invaders>().ResetInvaders();
            Invoke("StartGame", 2);
        }
        else
        {
            gameOverText.SetActive(true);
            Time.timeScale = 0;
            StopAllCoroutines();
            Debug.Log("GAME OVER!"); // Logga för att se om detta körs
        }
    }

    void StartGame()
    {
        stopGame = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        
    }
}

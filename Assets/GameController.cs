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
    public GameObject mainMenuPrefab;
    private GameObject currentMenu;
    [SerializeField] Healthbar healthbar;

    void Start()
    {
        playerStartPos = player.position;
        waveStartPos = wave.position;
        
        StartCoroutine(SpawnMysteryShip());
        gameOverText.SetActive(false);
        ShowMainMenu();

    }
    public void ShowMainMenu()
    {
        Debug.Log("Showing main menu"); // Logg f�r att se om metoden anropas
        if (currentMenu != null)
        {
            Destroy(currentMenu);
        }

        currentMenu = Instantiate(mainMenuPrefab);
        currentMenu.SetActive(true); // Se till att menyn �r aktiv
        Debug.Log("Main menu instantiated"); // Logg f�r att se att menyn har skapats
    }
    public void HideMainMenu()
    {
        if (currentMenu != null)
        {
            Destroy(currentMenu); // Ta bort menyn fr�n scenen
            Debug.Log("Main menu hidden"); // Logg f�r att se att menyn har dolts
        }
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
    public void StartGame()
    {
        Debug.Log("StartGame() anropades"); // F�r att se om metoden k�rs
        stopGame = false;
        Time.timeScale = 1;
        HideMainMenu();

        health = 3; // �terst�ll h�lsan
        healthbar.UpdateHealth(); // Uppdatera h�lsobaren
        playerStartPos = player.position;
    }

    public void GameOver()
    {
        Debug.Log("Game Over Triggered");
        stopGame = true; // Stoppa spelet
        ShowMainMenu(); // Visa menyn
    }
}

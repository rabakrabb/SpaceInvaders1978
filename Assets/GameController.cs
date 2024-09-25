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

    void Start()
    {
        playerStartPos = player.position;
        waveStartPos = wave.position;
    }

    public void Reset()
    {
        stopGame = true;

        if (health > 0) ////////stoppar ej spelet vid 0??
        {
            player.position = playerStartPos;
            wave.position = waveStartPos;
            health--;
            GameObject.FindObjectOfType<Invaders>().ResetInvaders();
            Invoke("StartGame", 2);
        }
        else
        {
            //game over!
        }
    }

    void StartGame()
    {
        stopGame = false;
    }

    void Update()
    {
        
    }
}

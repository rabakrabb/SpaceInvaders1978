using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    [SerializeField] Rigidbody2D rBody;
    [SerializeField] float missileSpeed = 13.0f;
    [SerializeField] float playerMissile;
    private ScoreManager scoreManager;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    private void Update()
    {
        if (GameController.stopGame)
        {
            Destroy(gameObject);
        }
    }
    public void Launch(Vector3 direction)
    {
        rBody.velocity = direction * missileSpeed;
        Destroy(gameObject, 3.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            scoreManager.UpdateScore(10); 
            Destroy(gameObject);
        }

        if (collision.CompareTag("Meteor"))
        {
            Destroy(gameObject); //FUNKAR INTE?!
        }
    }

}

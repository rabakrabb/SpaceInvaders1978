using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    [SerializeField] float missileSpeed = 6.0f;
    

    void Start()
    {
        Destroy(gameObject, 3.0f);
    }

    private void Update()
    {
        transform.Translate(Vector2.down * missileSpeed * Time.deltaTime);
        if (GameController.stopGame)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(1);
            GameObject.FindWithTag("Controller").GetComponent<GameController>().Reset();
        }
        if (collision.CompareTag("Meteor"))
        {
            Destroy(gameObject);
        }
    }
}

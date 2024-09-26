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
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
                Destroy(gameObject);
            }
        }
        if (collision.CompareTag("Meteor"))
        {
            Destroy(gameObject);
        }
    }
}

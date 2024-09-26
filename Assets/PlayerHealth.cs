using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Healthbar healthbar;
    public int health = 3;
    private GameController gameController;
    private bool isDamaged = false;

    private void Start()
    {
        gameController = GameObject.FindWithTag("Controller").GetComponent<GameController>();
        healthbar.UpdateHealth();
    }

    public void TakeDamage(int damage)
    {
        if (isDamaged) return; 

        isDamaged = true;
        health -= damage;
        health = Mathf.Clamp(health, 0, 3);
        healthbar.UpdateHealth();

        if (health <= 0)
        {
            gameController.Reset();
            Destroy(gameObject);
        }

        
        StartCoroutine(ResetDamage());
    }

    private IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        isDamaged = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
        }
    }
}

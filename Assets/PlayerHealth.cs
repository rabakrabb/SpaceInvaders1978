using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] UnityEvent playerDied;
    [SerializeField] Healthbar healthbar;
    public int health = 3;
    private GameController gameController;
    private bool isDamaged = false;
    public GameObject mainMenuCanvas;

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
            playerDied.Invoke();
            //gameController.Reset();
            //mainMenuCanvas.SetActive(true);
            gameController.GameOver();
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

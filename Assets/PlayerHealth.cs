using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] UnityEvent healthUpdated;
    public int health = 3;


    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, 3);
        healthUpdated.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            Destroy(collision.collider.gameObject);
            health -= 1;
            if(health <= 0)
            {
                Destroy(gameObject);
            }

        }
    }

    public void SetHealth(int health)
    {

    }
public int GetHealth()
    {
        return health;
    }
}

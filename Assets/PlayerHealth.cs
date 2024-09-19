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

public void SetHealth(int health)
    {

    }
public int GetHealth()
    {
        return health;
    }
}

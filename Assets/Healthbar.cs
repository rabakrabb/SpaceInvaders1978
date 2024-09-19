using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image[] ships; //0, 1, 2
    [SerializeField] PlayerHealth playerHealth;
   /* private void Start()
    {
        UpdateHealth();
    }
   */
    public void UpdateHealth()
    {
        int currentHealth = playerHealth.health;
        for (int i = 0; i < ships.Length; i++)
        {
            Image ship = ships[i];
            if (currentHealth > i)
            {
                ship.color = Color.white;
            }
            else
            {
                ship.color = Color.red;
            }
        }
    }
}
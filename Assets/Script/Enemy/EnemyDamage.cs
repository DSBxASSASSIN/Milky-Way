using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{

    public float hp = 100;
    private float currentHealth;

    void Start()
    {
        currentHealth = hp;    
    }

    [Header("Unity stuff")]
    public Image healthBar;

public void TakeDamage (int damage)
    {
        currentHealth -= damage;
        Debug.Log("DAMAGE!!!!!!!!!");
        healthBar.fillAmount = currentHealth / hp;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
   
}

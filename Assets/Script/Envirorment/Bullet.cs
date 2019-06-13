using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 25;
    public Rigidbody2D rb;
    
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        speed = rb.velocity.magnitude;
        if (speed < 0.1)
        {
            Destroy(gameObject);
        }
    }

     void OnTriggerEnter2D (Collider2D hitInfo)
     {
        EnemyDamage enemyDamage = hitInfo.GetComponent<EnemyDamage>();
       if (enemyDamage != null)
        {
            enemyDamage.TakeDamage(damage);
        }
        if (hitInfo.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
     }
}

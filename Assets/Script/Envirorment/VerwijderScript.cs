using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerwijderScript : MonoBehaviour
{
    public static bool alife = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground")|| collision.gameObject.CompareTag("Player"))
            {
            alife = true;
            Destroy(gameObject);
        }
    }

}

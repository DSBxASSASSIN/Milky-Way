using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VliegEnemyScript : MonoBehaviour
{
    public float distance;
    public float speed;
    public bool ismoving = true;
    public bool movingRight = true;

    public Transform wallDetection;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(wallDetection.position, Vector2.down);
        if (groundInfo.collider != null)
        {
            if (groundInfo.collider.gameObject.CompareTag("Player"))
            {
                ismoving = false;
            }
        }

        if (ismoving)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.position += (-Vector3.up * speed * 3 * Time.deltaTime);
        }

       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.tag.Equals("Wall")){
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;

            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        
    }
}

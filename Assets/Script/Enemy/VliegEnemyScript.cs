using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VliegEnemyScript : MonoBehaviour
{
    public float distance;
    public float speed;
    public bool ismoving = true;
    public bool movingRight = true;

    public bool alive = true;

    private Spawn _spawnerReference;
    public Spawn SpawnerReference
    {
        set
        {
            _spawnerReference = value;
        }
    }


    public Transform wallDetection;
    private Rigidbody2D rb;
    private Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", true);
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
            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        }
        else
        {
            transform.position += (-Vector3.up * speed * 3 * Time.deltaTime);
            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
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

        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("Player"))
        {
            alive = false;

            _spawnerReference.enemyAlife = false;
            Destroy(gameObject);
        }

    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{

    public float Speed = 60f;
    private Rigidbody2D rb;
    public bool isGrounded;
    public bool isGrounded2;
    public Transform check;
    public Transform check2;
    public LayerMask mask;
    private Animator animator;

    bool isFacingRight = true;
    public float jumpHeight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update() // script voor het lopen
    {

        isGrounded = Physics2D.OverlapCircle(check.position, 0.01f, mask);
        isGrounded2 = Physics2D.OverlapCircle(check2.position, 0.01f, mask);

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(Speed * Time.deltaTime, rb.velocity.y);
            isFacingRight = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = new Vector3(0 * Time.deltaTime, rb.velocity.y);
            isFacingRight = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            isFacingRight = false;
            rb.velocity = new Vector3(0 * Time.deltaTime, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            isFacingRight = false;
            rb.velocity = new Vector3(-Speed * Time.deltaTime, rb.velocity.y);
        }



        if (Input.GetKey(KeyCode.W)&& (isGrounded || isGrounded2)) //springen
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        animator.SetFloat("Speed", Mathf.Abs (rb.velocity.x)); // animation
            animator.SetFloat("Grounded 0", Mathf.Abs(rb.velocity.y));
       
        

    }

    private void FixedUpdate() //omdraaien van de character
    {
        if (isFacingRight)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (!isFacingRight)
        {
            transform.localEulerAngles = new Vector3(0, -180, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

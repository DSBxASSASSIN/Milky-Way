using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public static bool active = false;
    private Animator animator;
    private float startTime = 0f;
    public float endTime;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            active = true;
            startTime = Time.time;
            animator.SetBool("Button_pressed", true);
        }

        if (startTime == endTime)
        {
            animator.SetBool("Button_pressed", false);
        }
    }
}
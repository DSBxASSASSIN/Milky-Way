using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript2 : MonoBehaviour
{
    public static bool active = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            active = true;
            animator.SetBool("Button_pressed", true);

        }
    }
}
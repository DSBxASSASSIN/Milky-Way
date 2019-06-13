using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wapen : MonoBehaviour
{

    public Transform firepoint;
    public int ammo;
    public GameObject bullet;
    private Animator animator;

    public float timer;
    private float timeBetweenBullets;
    public float startTimeBetweenShots;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenBullets <= 0)
        {
            if (ammo > 0 && Input.GetButtonDown("Fire1"))
            {
                Shoot();
                timeBetweenBullets = startTimeBetweenShots;
                
            }
        }
        else
        {
            timeBetweenBullets -= Time.deltaTime;
        }

        

        if (timer >= 0.5f)
        {
            animator.SetBool("fired", false);
            timer = 0f;
        }

    }

    void Shoot()
    {
        Instantiate(bullet, firepoint.position, firepoint.rotation);
        Debug.Log("ik will dood");
        animator.SetBool("fired", true);
        timer += 1 * Time.deltaTime;
        //ammo--;

    }

    //public void GiveAmmo()
    //{
    //    ammo+=5;
    //}
}

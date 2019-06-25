using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_gass : MonoBehaviour
{

    public float Explosion_Delay = 1f;
    public float Explosion_Rate = 0.2f;
    public float Explosion_Max_Size = 0.4f;
    public float Explosion_Length = 1f;
    public float Current_Radius = 0f;
    public float Explosion_Force = 200f;
    public float Current_Length = 0f;

    public Transform groundDetection;
    public float distance;
    CircleCollider2D Explosion_Radius;
    bool active = true;
    RaycastHit2D rayInfo;
    public static bool exploded = false;
    public bool explodedBool = false;

    void Start() {
        gameObject.GetComponent<Animator>().SetBool("Exploded", false);
        Explosion_Radius = gameObject.GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        rayInfo = Physics2D.Raycast(groundDetection.position, Vector2.left, distance);
        Debug.DrawRay(groundDetection.position, Vector2.left);
        if (rayInfo.collider && distance <= 2)
        {
            Explosion_Delay -= Time.deltaTime;
            if (Explosion_Delay < 0)
            {
                if (active)
                {
                    explodedBool = true;
                    gameObject.GetComponent<Animator>().SetBool("Exploded", true);
                    gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    active = false;
                    //done = true;
                }
            }
        }

        if (explodedBool)
        {
            Current_Radius++;
        }

        if (Current_Radius > 50)
        {
            //PlayerHpScript.hp--;
            Destroy(transform.parent.gameObject);
        }
    }

    private void FixedUpdate() {
        //if (exploded) {
            //if(Current_Radius < Explosion_Max_Size) {
            //    Current_Radius += Explosion_Rate;
            //    Current_Length++;
            //} else {
            //    Destroy(gameObject.transform.parent.gameObject);
            //}
            //if (done)
            //{
            //    Destroy(gameObject.transform.parent.gameObject);
            //}

            //if (Current_Length >= (Explosion_Length * 10))
            //{
            //    Destroy(gameObject.transform.parent.gameObject);
            //}
            //Explosion_Radius.radius = Current_Radius;   
        //}
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (exploded) {
            if (col.gameObject.GetComponent<Rigidbody2D>() != null) {
                //Vector2 Target = col.gameObject.transform.position;
                //Vector2 Bomb = gameObject.transform.position;
                //Vector2 Direction = Explosion_Force * (Target - Bomb);

                //col.gameObject.GetComponent<Rigidbody2D>().AddForce(Direction);
                Debug.Log("dammage 1");
            }
        }
    }
}


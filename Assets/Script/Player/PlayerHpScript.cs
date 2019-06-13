using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHpScript : MonoBehaviour
{
    public static int hp = 3;
   
    private bool alreadyDamaged = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //if (hp == 0)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //}

        Damage();
        restartScene();

    }

    public void restartScene()
    {
        if (hp == 0)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("The Game");
        }
    
 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            hp--;
        }
    }

    private void Damage()
    {
        if (GameObject.FindGameObjectWithTag("Plant") != null)
        {
            if (GameObject.FindGameObjectWithTag("Plant").GetComponent<Explosion_gass>().explodedBool)
            {
                if (!alreadyDamaged)
                {
                    hp--;
                    alreadyDamaged = true;
                }
            }
        }
    }
}

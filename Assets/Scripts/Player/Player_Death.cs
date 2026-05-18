using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public GameManager gm;
    public GameManager_Level3 level3;
    //public GameObject goverscreen;

    [SerializeField] private AudioSource dead;
    // public HealthManager health;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameManager>();
        level3 = GetComponent<GameManager_Level3>();
     //   health = GetComponent<HealthManager>();
    }

            //to put ignorelayer

   /* private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            health.health--;
            if (health.health <= 0)
            {
                playerDead();
            }
        }
    }*/

    public void playerDead()
    {
        dead.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        restartGame();
        //goverscreen.SetActive(true); 
      //  level3.gameover_restart();
       // gm.gameOver();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile_Level5 : MonoBehaviour
{

    public Rigidbody2D projectileRb;
    public float speed;

    public float projectileLife;
    public float projectileCount;

    public Player_Movement Player_Movement;
    public bool facingRight;

    public Level3_Finish level3;
   
    void Start()
    {
        projectileCount = projectileLife;
        Player_Movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
        facingRight = Player_Movement.facingRight;

        if (!facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void Update()
    {
        projectileCount -= Time.deltaTime;
        if (projectileCount <= 0)
        {
            Destroy(gameObject);
        }

        //nextlevel();
    }

    private void FixedUpdate()
    {
        if (facingRight)
        {
            projectileRb.velocity = new Vector2(speed, projectileRb.velocity.y);
        }
        else
        {
            projectileRb.velocity = new Vector2(-speed, projectileRb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().takeDamageboss(2);
            Destroy(gameObject);
            level3.enemykillcount++;
        }
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Flag")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "projectile")
        {
            Destroy(gameObject);
        }
    }
   /* private void nextlevel()
    {
        if (enemykill == enemyNeedToKill)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }*/
}


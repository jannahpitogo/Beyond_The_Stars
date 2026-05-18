using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{

    public Rigidbody2D projectileRb;
    public float speed;

    public float projectileLife;
    public float projectileCount;

    public Player_Movement Player_Movement;
    public bool facingRight;

    

    void Start()
    {
        
        projectileCount = projectileLife;
        Player_Movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
        facingRight = Player_Movement.facingRight;

        if(!facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void Update()
    {
        projectileCount -= Time.deltaTime;
        if(projectileCount <= 0)
        {
            Destroy(gameObject);
        }
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
            collision.gameObject.GetComponent<EnemyHealth>().takeDamage(1);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Flag")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemyprojectile")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
      
    }


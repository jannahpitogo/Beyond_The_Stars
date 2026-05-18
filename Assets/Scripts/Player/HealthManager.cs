using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 3;
    public int health = 3;

    public Image[] hearts;
    public Sprite full;
    public Sprite empty;

    public Player_Life death;
    [SerializeField] private AudioSource hurtsound;

    public Animator anim;
    public Player_Movement player;

    private void Start()
    {
        death = GetComponent<Player_Life>();
        anim = GetComponent<Animator>();
        health = maxHealth;
    }
    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = empty;
        }
        for (int i = -0; i < health; i++)
        {
            hearts[i].sprite = full;
        }

        if (health <= 0)
        {
            death.playerDead();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hurtsound.Play();
            health--;
            if (anim != null)
            {
                anim.SetTrigger("hurt");
            }
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            hurtsound.Play();
            if (anim != null)
            {
                anim.SetTrigger("hurt");
            }
        }
        else if (collision.gameObject.CompareTag("Enemyprojectile"))
        {
            hurtsound.Play();
            health--;
            if (anim != null)
            {
                anim.SetTrigger("hurt");
            }
        }

        
         
        }
    }


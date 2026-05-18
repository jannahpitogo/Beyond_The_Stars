using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int bossHealth = 10;
    public int bosscurrentHealth;
    public int maxHealth = 3;
    public int currentHealth;

    private Animator anim;
    void Start()
    {
        currentHealth = maxHealth;
        bosscurrentHealth = bossHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int amount)
    {
        currentHealth -= amount;
        if (anim != null)
        {
            anim.SetTrigger("hurt");
        }
        if(currentHealth <= 0)
        {
            if(anim != null)
            {
                anim.SetTrigger("death");
            }
            Destroy(gameObject);
        }
    }

    public void takeDamageboss(int amount)
    {
        bosscurrentHealth -= amount;
        if (anim != null)
        {
            anim.SetTrigger("hurt");
        }
        if (currentHealth <= 0)
        {
            if (anim != null)
            {
                anim.SetTrigger("death");
            }
            Destroy(gameObject);
        }
    }
}

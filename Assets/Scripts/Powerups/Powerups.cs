using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Gravity : MonoBehaviour
{



    public Player_Movement player;
    public Rigidbody2D rb;
    void Start()
    {
        player = GetComponent<Player_Movement>();
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.rb.gravityScale = 1;
            Destroy(gameObject);
           
        }
    }
}

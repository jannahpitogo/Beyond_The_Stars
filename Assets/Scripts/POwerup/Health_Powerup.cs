using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Powerup : MonoBehaviour
{


    public HealthManager hm;
    void Start()
    {
        hm = GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (hm.health < hm.maxHealth)
            {
                hm.health++;
            }
            else
            {
                Destroy(gameObject);
            }

            Destroy(gameObject);
        }
    
      }
    
}

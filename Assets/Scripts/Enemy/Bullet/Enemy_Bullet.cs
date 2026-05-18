using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;

    public HealthManager health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        health = GetComponent<HealthManager>();

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
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
        if (collision.gameObject.tag == "projectile")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}

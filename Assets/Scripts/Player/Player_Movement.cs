using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    private SpriteRenderer spR;
    bool isGrounded = true;

    public float jumpForce = 10.0f;
    public float playerSpeed = 8.0f;
    public float dirX = 0f;
    public GameManager cm;
    private enum MovementState { idle, running, jumping, falling }

    public bool flippedLeft;
    public bool facingRight;

    [SerializeField] private AudioSource jump;
    [SerializeField] private AudioSource collect;

    // public GameManager_Level3 level3;
    public GameObject gravityscreen;
    public HealthManager health;
    public GameObject healthscreen;
    public GameObject jumpscreen;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cm = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameManager>();
        //    level3 = GetComponent<GameManager_Level3>();
        health = GetComponent<HealthManager>();
    }

    void Update()

    {

        //Getting the horizontal controls
        dirX = Input.GetAxis("Horizontal");

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        //Movement
        rb.velocity = new Vector2(dirX * playerSpeed, rb.velocity.y);

        //Flipping the player left & right
        if (dirX > 0.01f)
        {
            facingRight = true;
            flip(true);
            // transform.localScale = new Vector3(2, 2, 2);
        }
        else if (dirX < -0.01f)
        {
            facingRight = false;
            flip(false);
            // transform.localScale = new Vector3(-2, 2, 2);
        }

        UpdateAnimationState();
    }




    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            // spR.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            // spR.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }


        anim.SetInteger("state", (int)state);
    }

    //COLLECTIBLE
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            collect.Play();
            Destroy(other.gameObject);
            Scene currentScene = SceneManager.GetActiveScene();
            int sceneIndex = currentScene.buildIndex;
            if (sceneIndex == 1)
            {
                cm.collectCount = cm.collectCount + 1;
            }
            else if (sceneIndex == 2)
            {
                cm.collectCount = cm.collectCount + 2;
            }
            else if (sceneIndex == 3)
            {
                cm.collectCount += 3;
            }
            else if (sceneIndex == 4)
            {
                cm.collectCount += 4;
            }
            else if (sceneIndex == 5)
            {
                cm.collectCount += 5;
            }

        }

        if (other.gameObject.CompareTag("Powerup_A"))
        {
            collect.Play();
            Destroy(other.gameObject);
            rb.gravityScale = 1.0f;
            gravityscreen.SetActive(true);
            StartCoroutine(GravityRest());
        }

        if (other.gameObject.CompareTag("Powerup_h"))
        {
            collect.Play();
            Destroy(other.gameObject);
            if (health.health < health.maxHealth)
            {
                health.health++;
            }
            healthscreen.SetActive(true);
            StartCoroutine(HealthRest());
        }

        if (other.gameObject.CompareTag("Powerup_J"))
        {
            collect.Play();
            Destroy(other.gameObject);
            jumpForce = 10f;
            jumpscreen.SetActive(true);
            StartCoroutine(jumptimer());
        }

        




    }



    //GROUND
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }



    /*public bool canAttack()
    {
        return dirX == 0 && isGrounded == true;
    }*/

    void flip(bool facingRight)
    {
        if (flippedLeft && facingRight)
        {
            transform.Rotate(0, -180, 0);
            flippedLeft = false;
        }

        if (!flippedLeft && !facingRight)
        {
            transform.Rotate(0, -180, 0);
            flippedLeft = true;
        }
    }

    private IEnumerator GravityRest()
    {
        yield return new WaitForSeconds(7);
        rb.gravityScale = 0.5f;
        //GetComponent<SpriteRenderer>().color = Color.white;
        gravityscreen.SetActive(false);

    }

    private IEnumerator HealthRest()
    {
        yield return new WaitForSeconds(3);
        //GetComponent<SpriteRenderer>().color = Color.white;
        healthscreen.SetActive(false);
    }

    private IEnumerator jumptimer()
    {
        yield return new WaitForSeconds(5);
        jumpForce = 5;
        //GetComponent<SpriteRenderer>().color = Color.white;
        jumpscreen.SetActive(false);
    }
}

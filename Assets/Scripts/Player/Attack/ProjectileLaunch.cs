using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{

    public GameObject projectilePreFab;
    public Transform launchPoint;

    public float shootTime;
    public float shootCounter;

    public AudioSource shootsound;
    public Animator anim;


    void Start()
    {
        shootCounter = shootTime;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && shootCounter <= 0)
        {
            if(anim != null)
            {
                anim.SetTrigger("attack");
            }
            shootsound.Play();
            Instantiate(projectilePreFab, launchPoint.position, Quaternion.identity);
            shootCounter = shootTime;
        }

        shootCounter -= Time.deltaTime;
    }
}

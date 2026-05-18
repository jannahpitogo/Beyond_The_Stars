using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3_Finish : MonoBehaviour
{

    public bool finish;
    public int enemykillcount;
    public int enemyneedtokill = 17;

    private void Start()
    {

    }



    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject hitobj = collider.gameObject;

        if (hitobj.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}

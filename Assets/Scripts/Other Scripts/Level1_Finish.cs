using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1_Finish : MonoBehaviour
{

    public GameManager gm;
    public bool finish;

    private void Start()
    {
        gm = gameObject.GetComponent<GameManager>();
    }



    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject hitobj = collider.gameObject;

        if (hitobj.tag == "Player")
        {
            finish = true;
        }
        else if(finish == true && gm.lvl == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager_Level3 : MonoBehaviour
{
    public int collectCount;
    public int currentSceneIndex;
    public Text scoreText;
    public GameObject gover;
    //public GameManager cm;
    public GameObject winScreen;
    public bool lvl;

    //public GameObject Gravity_Powerup;
    //public Level1_Finish finCondition;

    void Start()
    {
        //cm = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameManager>();
        collectCount = 0;
       // lvl = false;
       // finCondition = GetComponent<Level1_Finish>();
        
    }

    void Update()
    {
        scoreText.text = "Score: " + collectCount.ToString();
        nextLevel();
       // winFinal();


    }

    public void gameOver()
    {
        Time.timeScale = 0.0f;
        gover.SetActive(true);
    }

    public void winGame()
    {
        winScreen.SetActive(true);
    }

 /*   public void winFinal()
    {
        if (lvl == 3 && collectCount == 7)
        {
            winGame();
        }
    }*/

    /*public void finish()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }*/

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }

    public void nextLevel()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
        }
    }

    /*   public void gravity_Collide()
       {
           Gravity_Powerup.SetActive(true);
       }*/

    public void gameover_restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
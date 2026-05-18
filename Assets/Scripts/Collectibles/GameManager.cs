using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int collectCount;
    public int currentSceneIndex;
    public Text scoreText;
    public GameObject gover;
    //public GameManager cm;
    public GameObject winScreen;
    public bool lvl;
    public GameObject Gravity_Powerup;

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
        //nextLevel();
        // winFinal();
        winCondition();


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


    public void finish()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }


    public void nextLevel()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


   /* public void nextLvlFlag()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }*/

    public void winCondition()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int sceneIndex = currentScene.buildIndex;
        if (sceneIndex == 1)
        {
            if( collectCount == 9)
            {
                nextLevel();
            }
        }
        else if (sceneIndex == 4)
        {
            if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && GameObject.FindGameObjectsWithTag("Collectible").Length == 0)
            {
                nextLevel();
            }
        }
        else if (sceneIndex == 5)
        {
            if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && GameObject.FindGameObjectsWithTag("Collectible").Length == 0)
            {
                winGame();
            }
        }
    }

    public void Gravity_collide()
    {
        Gravity_Powerup.SetActive(true);
    }
   

}
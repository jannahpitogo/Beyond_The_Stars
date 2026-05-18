using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject optionPanel;
    public GameObject play;
    public GameObject option;
    public GameObject quit;

  
    public void PlayGame()
    {
       
        SceneManager.LoadSceneAsync(1);
        
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void Option()
    {
        optionPanel.SetActive(true);
        play.SetActive(false);
        option.SetActive(false);
        quit.SetActive(false);

    }

   public void main()
    {
        optionPanel.SetActive(false);
        play.SetActive(true);
        option.SetActive(true);
        quit.SetActive(true);
    }
}

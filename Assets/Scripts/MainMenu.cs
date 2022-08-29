using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject PlayButtonObject;
    public GameObject QuitButtonObject;

    private bool GameIsPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           
           if(GameIsPaused)
            {
                ResumeGame();
            } 
           else
            {
                PauseGame();
            }
            Button PlayButton = PlayButtonObject.GetComponent<Button>();
            Button QuitButton = QuitButtonObject.GetComponent<Button>();
            PlayButton.onClick.AddListener(ResumeGame);
            QuitButton.onClick.AddListener(ExitGame);

        }

    }

    public void PauseGame()
    {
        MainMenuPanel.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        GameIsPaused = false;
        MainMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        MainMenuPanel.SetActive(false);
        Application.Quit();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        MainMenuPanel.SetActive(false);
        GameOver.Restart();
    }
}

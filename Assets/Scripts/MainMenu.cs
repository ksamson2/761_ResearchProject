using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject PlayButtonObject;
    public GameObject QuitButtonObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("capture key");
            MainMenuPanel.SetActive(true);
            PauseGame();
            Button PlayButton = PlayButtonObject.GetComponent<Button>();
            Button QuitButton = QuitButtonObject.GetComponent<Button>();
            PlayButton.onClick.AddListener(ResumeGame);
            QuitButton.onClick.AddListener(ExitGame);

        }

    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    void ExitGame()
    {
        Application.Quit();
    }
}

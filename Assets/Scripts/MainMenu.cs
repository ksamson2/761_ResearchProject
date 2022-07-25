using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject PlayButtonObject;
    public GameObject PauseButtonObject;
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
            Button PlayButton = PlayButtonObject.GetComponent<Button>();
            Button PauseButton = PauseButtonObject.GetComponent<Button>();
            Button QuitButton = QuitButtonObject.GetComponent<Button>();
            PlayButton.onClick.AddListener(ResumeGame);
            PauseButton.onClick.AddListener(PauseGame);
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

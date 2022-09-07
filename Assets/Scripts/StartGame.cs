using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject PlayButtonObject;


    private void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

        Button PlayButton = PlayButtonObject.GetComponent<Button>();
        PlayButton.onClick.AddListener(StartGamePlay);
    }


    public void StartGamePlay()
    {
        StartPanel.SetActive(false);
        Time.timeScale = 1;
    }
}

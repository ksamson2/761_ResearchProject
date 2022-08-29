using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel; 

    // Update is called once per frame
    void Update()
    {
      if(GameObject.FindGameObjectWithTag("Player") == null)
      {
          gameOverPanel.SetActive(true);
      }  
    }

    public static void Restart()
    {
        PlayerPrefs.SetFloat("FlowerBadgesTotal", PlayerCollision.FlowerBadgesCollected);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerCollision.MarshmallowPoints = 0;
        PlayerCollision.FlowerBadgesCollected = 0;
        ScoreManager.score = 0;
        PlayerCollision.BubbleTotal = 0;
        PlayerCollision.TotalTeaLeaves = 0; 
    }
}

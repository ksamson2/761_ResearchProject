using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public static float MarshmallowPoints;
    private GameObject Player;
    public GameObject InputField;
    public GameObject SubmitThoughtButtonObject;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        
        InputField.SetActive(false);
        SubmitThoughtButtonObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle") 
        {
            if (MarshmallowPoints >= 12 )
            {
                MarshmallowPoints -= 12;
            }
            else
            {
                // Destroy(Player.gameObject);
            }
        }
        if (collision.gameObject.tag == "MarshmallowPoint")
        {
            Destroy(collision.gameObject);
            MarshmallowPoints++;
        }
        if (collision.gameObject.tag == "Bubble")
        {
            PauseGame();
            InputField.SetActive(true);
            SubmitThoughtButtonObject.SetActive(true);
            Button SubmitThoughtButton = SubmitThoughtButtonObject.GetComponent<Button>();
            SubmitThoughtButton.onClick.AddListener(DecenteringButton); 

        }
    }

    void DecenteringButton()
    {
        InputField.SetActive(false);
        SubmitThoughtButtonObject.SetActive(false);
        ResumeGame();
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}

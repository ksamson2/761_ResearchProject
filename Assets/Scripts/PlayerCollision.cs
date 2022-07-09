using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public float marshmallowPoints; 
    private GameObject player;
    public GameObject inputField;
    public GameObject submitThoughtButton;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inputField.SetActive(false);
        submitThoughtButton.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle") 
        {
            // Destroy(player.gameObject);
        }
        if (collision.gameObject.tag == "MarshmallowPoint")
        {
            Destroy(collision.gameObject);
            marshmallowPoints++;
            Debug.Log(marshmallowPoints);
        }
        if (collision.gameObject.tag == "Bubble")
        {
            PauseGame();
            inputField.SetActive(true);
            submitThoughtButton.SetActive(true);
            Button submitThoughtbtn = submitThoughtButton.GetComponent<Button>();
            submitThoughtbtn.onClick.AddListener(DecenteringButton); 

        }
    }

    void DecenteringButton()
    {
        inputField.SetActive(false);
        submitThoughtButton.SetActive(false);
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

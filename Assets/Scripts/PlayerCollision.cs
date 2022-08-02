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
    private GameObject bubble;
    [SerializeField]
    private AudioSource BubbleSound;
    [SerializeField]
    private AudioSource TeaLeaveSound;

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
                Player.gameObject.GetComponent<Animator>().enabled = false;
                Destroy(Player.gameObject);
            }
        }
        if (collision.gameObject.tag == "MarshmallowPoint")
        {
            TeaLeaveSound.Play();
            Destroy(collision.gameObject);
            MarshmallowPoints++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bubble")
        {
            bubble = collision.gameObject;
            if (bubble.GetComponent<Bubble>().FloatAway == false)
            {
                BubbleSound.Play();
                PauseGame();
                InputField.SetActive(true);
                SubmitThoughtButtonObject.SetActive(true);
                Button SubmitThoughtButton = SubmitThoughtButtonObject.GetComponent<Button>();
                SubmitThoughtButton.onClick.AddListener(DecenteringButton);
            }
        }
    }
    void DecenteringButton()
    {

        InputField.SetActive(false);
        // var InputFieldText = InputField.GetComponent<InputField>();
        // InputFieldText.text = "";
        SubmitThoughtButtonObject.SetActive(false);
        bubble.GetComponent<Bubble>().FloatAway = true;
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

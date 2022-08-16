using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
 
    public static float MarshmallowPoints;
    public static float TotalTeaLeaves = 0;
    public static float BubbleTotal;
    private GameObject Player;
    public GameObject InputField;
    public GameObject SubmitThoughtButtonObject;
    public TMP_InputField UserInput;

    private GameObject bubble;
    [SerializeField]
    private AudioSource BubbleSound;
    [SerializeField]
    private AudioSource TeaLeaveSound;
    public static float LIFE_POINTS_AMOUNT = 12;
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
            if (MarshmallowPoints >= LIFE_POINTS_AMOUNT)
            {
                MarshmallowPoints -= LIFE_POINTS_AMOUNT;
            }
            else
            {
                //Player.gameObject.GetComponent<Animator>().enabled = false;
                //Destroy(Player.gameObject);
            }
        }
        if (collision.gameObject.tag == "MarshmallowPoint")
        {
            TeaLeaveSound.Play();
            Destroy(collision.gameObject);
            if(MarshmallowPoints < LIFE_POINTS_AMOUNT)
            {
                MarshmallowPoints++;
            }
            TotalTeaLeaves++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bubble")
        {
            BubbleTotal++;
            bubble = collision.gameObject;
            if (bubble.GetComponent<Bubble>().FloatAway == false)
            {
                BubbleSound.Play();
                PauseGame();
                InputField.SetActive(true);
                UserInput.ActivateInputField();
                SubmitThoughtButtonObject.SetActive(true);
                Button SubmitThoughtButton = SubmitThoughtButtonObject.GetComponent<Button>();
                SubmitThoughtButton.onClick.AddListener(DecenteringButton);
            }
        }
    }
    void DecenteringButton()
    {

        InputField.SetActive(false);
        UserInput.GetComponentInChildren<TMP_InputField>().text = "";
        SubmitThoughtButtonObject.SetActive(false);
        bubble.GetComponent<Renderer>().material.color = Color.black;
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

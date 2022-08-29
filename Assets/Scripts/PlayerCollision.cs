using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
 
    public static float MarshmallowPoints;
    public static float FlowerBadgesCollected = 0;
    public static float TotalTeaLeaves = 0;
    public static float BubbleTotal;
    private GameObject Player;
    public GameObject DecenteringText;
    public GameObject SubmitThoughtButtonObject;

    public Rigidbody2D ShuheiRB;
    public GameObject RightBorder; 
    private GameObject bubble;
    [SerializeField]
    private AudioSource BubbleSound;
    [SerializeField]
    private AudioSource TeaLeaveSound;
    [SerializeField]
    private AudioSource RockHitSound;
    public static float COMPLETE_TEA_LEAF_VALUE = 11; // Array indexed - tea leaf total is 12
    public float HitRate;
    private bool IsHit = false;
    private bool IsCollidedWithBubble = false;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        DecenteringText.SetActive(false);
        SubmitThoughtButtonObject.SetActive(false); 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && IsCollidedWithBubble)
        {
            DecenteringButton();
            IsCollidedWithBubble = false;
        }
        if (Time.time < HitRate)
        {
            if (IsHit)
            {
                Player.gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            }
        }
        else
        {
            Player.gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            IsHit = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            RockHitSound.Play();
            IsHit = true;
            HitRate = Time.time + 2;
           
        }
        if (collision.gameObject.tag == "MarshmallowPoint")
        {
            TeaLeaveSound.Play();
            Destroy(collision.gameObject);

            if (MarshmallowPoints == COMPLETE_TEA_LEAF_VALUE)
            {
                MarshmallowPoints -= COMPLETE_TEA_LEAF_VALUE;

                if (transform.position.x + 2 < RightBorder.transform.position.x)
                {
                    ShuheiRB.GetComponent<Rigidbody2D>().transform.position = transform.position + new Vector3(2, 0, 0);
                }
               
            }

            if (MarshmallowPoints < COMPLETE_TEA_LEAF_VALUE)
            {
                MarshmallowPoints++;
            }
            TotalTeaLeaves++;
        }
        if (collision.gameObject.tag == "Tutorial")
        {
            RockHitSound.Play();
        }
        if(collision.gameObject.tag == "FlowerBadge")
        {
            FlowerBadgesCollected++;
            Destroy(collision.gameObject);
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
                IsCollidedWithBubble = true;
                SubmitThoughtButtonObject.SetActive(true);
                DecenteringText.SetActive(true);
                Button SubmitThoughtButton = SubmitThoughtButtonObject.GetComponent<Button>();
                SubmitThoughtButton.onClick.AddListener(DecenteringButton);

            }
            
        }
    }


    void DecenteringButton()
    {
        // InputField.SetActive(false);
        // UserInput.GetComponentInChildren<TMP_InputField>().text = "";
        SubmitThoughtButtonObject.SetActive(false);
        DecenteringText.SetActive(false);
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

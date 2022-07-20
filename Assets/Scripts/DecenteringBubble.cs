using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecenteringBubble : MonoBehaviour
{

    public GameObject InputField;
    public GameObject SubmitThoughtButtonObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PauseGame();
            InputField.SetActive(true);
            SubmitThoughtButtonObject.SetActive(true);
            Button SubmitThoughtButton = SubmitThoughtButtonObject.GetComponent<Button>();
            var Bubble = gameObject.GetComponent<Sprite>();
            SubmitThoughtButton.onClick.AddListener(DecenteringButton);

        }
    }

    void DecenteringButton()
    {

        InputField.SetActive(false);
        SubmitThoughtButtonObject.SetActive(false);
        transform.Translate(Vector3.up * Time.deltaTime, Space.World);
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;
    public Text ScoreTextInGame;
    public Text TeaLeavesTotal;
    public Text BubbleTotal;
    public Text TotalScore;
    public float score;

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null) 
        {
            score += 1 * Time.deltaTime; 
            ScoreText.text = ((int)score).ToString();
            ScoreTextInGame.text = ((int)score).ToString();

            float BubbleTotalScore = PlayerCollision.BubbleTotal;
            BubbleTotal.text = BubbleTotalScore.ToString(); 

            float TotalTeaLeaves = PlayerCollision.TotalTeaLeaves;
            TeaLeavesTotal.text = ((int)TotalTeaLeaves).ToString();

            TotalScore.text = ((int)score + TotalTeaLeaves + BubbleTotalScore).ToString();
            
        }
    }
}

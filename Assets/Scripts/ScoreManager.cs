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
    public static float score { get; private set; }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null) 
        {
            score += 1 * Time.deltaTime; 
            string ScoreValue = ((int)score).ToString();
            int Minutes = (int)score / 60;
            int Seconds = (int)score % 60;
            ScoreText.text = ((int)score).ToString();
            ScoreTextInGame.text = Minutes.ToString() + ":" + Seconds.ToString();

            float BubbleTotalScore = PlayerCollision.BubbleTotal;
            BubbleTotal.text = BubbleTotalScore.ToString(); 

            float TotalTeaLeaves = PlayerCollision.TotalTeaLeaves;
            TeaLeavesTotal.text = ((int)TotalTeaLeaves).ToString();

            TotalScore.text = ((int)score + TotalTeaLeaves + BubbleTotalScore).ToString();
            
        }
    }
}

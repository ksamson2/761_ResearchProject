using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;
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
            float BubbleTotal = PlayerCollision.BubbleTotal;
            float TotalTeaLeaves = PlayerCollision.TotalTeaLeaves;
            TotalScore.text = ((int)score + TotalTeaLeaves + BubbleTotal).ToString(); 
        }

        var TeaLeaves = PlayerCollision.MarshmallowPoints;
        TeaLeavesTotal.text = ((int)TeaLeaves).ToString();
    }
}

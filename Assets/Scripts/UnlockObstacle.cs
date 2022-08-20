using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockObstacle : MonoBehaviour
{
	[SerializeField] private int TimeToIncreaseDifficulty;
    private int CurrentTimeMet;

	private void Update()
    {
        int CurrentScore = (int)ScoreManager.score;
        if(CurrentScore % TimeToIncreaseDifficulty == 0 & CurrentScore != CurrentTimeMet)
        {

            CurrentTimeMet = CurrentScore;
            if (SpawnObstacles.ObstaclesUnlockedTotal < SpawnObstacles.ObstaclesToUnlockMax)
            {
                SpawnObstacles.ObstaclesUnlockedTotal++;
                TimeToIncreaseDifficulty += TimeToIncreaseDifficulty;

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockObstacle : MonoBehaviour
{
	[SerializeField] private float TimeToIncreaseDifficulty;
    public ScoreManager ScoreManager;

	private void Update()
    {
        float CurrentScore = ScoreManager.score;

    }
}

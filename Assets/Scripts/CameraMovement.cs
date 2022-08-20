using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;
    public float increaseSpeed;
    public  static bool Pause = false;
    private int CurrentTime;
    private int PreviousTime;
    // Update is called once per frame
    void Update()
    {
        if (Pause)
        {
            return;
        }
        else
        {
            transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
            CurrentTime = (int)ScoreManager.score;
            //if (CurrentTime % 10 == 0 && CurrentTime != PreviousTime)
            //{
            //    PreviousTime = CurrentTime; 
            //    cameraSpeed += 0.1f;
            //    Debug.Log(cameraSpeed);
            //}
        }
    }
}

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
    void FixedUpdate()
    {
        if (Pause)
        {
            return;
        }
        else
        {
            transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
            CurrentTime = (int)ScoreManager.score;
        }
    }
}

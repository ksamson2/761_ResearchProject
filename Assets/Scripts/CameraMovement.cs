using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;
    public float increaseSpeed;
    public  static bool Pause = false;
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
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    private float Length, StartPosition;
    public GameObject Cam;
    public float ParallaxEffect;
    // Update is called once per frame
    //void Update()
    //{
    //    BackgroundRenderer.material.mainTextureOffset += new Vector2(BackgroundSpeed * Time.deltaTime, 0f);
    //    // SetTextureOffset("_MainTex", Vector2(offset, 0));
    //}

    void Start()
    {
        StartPosition = transform.position.x;
        Length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    void FixedUpdate()
    {
        float CameraDistance = (Cam.transform.position.x * (1 - ParallaxEffect));
        float Distance = (Cam.transform.position.x * ParallaxEffect);
        transform.position = new Vector3(StartPosition + Distance, transform.position.y, transform.position.z);
        
        if (CameraDistance > StartPosition + Length)
        {
            StartPosition += Length;
        }
        else if ( CameraDistance < StartPosition - Length)
        {
            StartPosition -= Length;
        }
    }
}

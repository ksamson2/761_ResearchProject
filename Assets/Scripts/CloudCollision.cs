using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "BreathingCloud")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BreathingCloud")
        {
            Destroy(gameObject);
        }
    }
}

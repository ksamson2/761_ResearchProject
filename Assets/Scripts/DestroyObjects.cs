using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    // Start is called before the first frame update
    private List<string> CollisionTags = new List<string> { "Obstacle", "Cloud", "Tutorial", "MarshmallowPoint", "Bubble", "BreathingCloud" };
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string Tag = collision.gameObject.tag; 
        if (Tag == "Player")
        {
            //Destroy(collision.gameObject);
        }

        bool FindTagInList = CollisionTags.Contains(Tag);
        if(FindTagInList)
        {
            Destroy(collision.gameObject);
        }

    }
}

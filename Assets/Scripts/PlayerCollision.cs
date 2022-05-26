using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCollision : MonoBehaviour
{
    public float marshmallowPoints; 
    private GameObject player;   

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle") 
        {
            // Destroy(player.gameObject);
        }
        if (collision.gameObject.tag == "MarshmallowPoint")
        {
            Destroy(collision.gameObject);
            marshmallowPoints++;
            Debug.Log(marshmallowPoints);
        }
    }
}

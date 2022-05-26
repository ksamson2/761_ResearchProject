using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCollision : MonoBehaviour
{
    public float marshmallowPoints; 
    private GameObject player;   
    private GameObject marshmallo;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        marshmallo = GameObject.FindGameObjectWithTag("MarshmallowPoint");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle") 
        {
            Destroy(player.gameObject);
        }
        if (collision.gameObject.tag == "MarshmallowPoint")
        {
            Destroy(marshmallo.gameObject);
            marshmallowPoints++;
            Debug.Log(marshmallowPoints);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Cloud")
        {
            Destroy(collision.gameObject);   
        }
        if (collision.gameObject.tag == "MarshmallowPoint")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Bubble")
        {
            Destroy(collision.gameObject);
        }
    }
}

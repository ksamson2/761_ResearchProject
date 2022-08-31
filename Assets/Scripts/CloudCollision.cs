using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollision : MonoBehaviour
{
    public int Radius = 10;
    //private void Update()
    //{
    //    Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, Radius);
        
    //    foreach (var hitCollider in hitColliders)
    //    {
    //        Debug.Log(hitCollider);
    //        if (hitCollider.GetComponent<GameObject>().tag == "Cloud")
    //        {
    //            Debug.Log("test");
    //            Destroy(hitCollider.GetComponent<GameObject>());
    //        }
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Cloud")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cloud")
        {
            Destroy(gameObject);
        }
    }
}

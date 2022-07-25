using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public bool FloatAway;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FloatAway)
        {
            gameObject.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        }
    }
}

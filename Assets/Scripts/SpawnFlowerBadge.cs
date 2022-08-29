using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlowerBadge : MonoBehaviour
{
    public float SpawnRate;
    public GameObject Flower; 
    public float FlowerBadgeMinX;
    public float FlowerBadgeMaxX;
    public float FlowerBadgeMinY;
    public float FlowerBadgeMaxY;

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (Time.time > SpawnRate)
        {
            Debug.Log(SpawnRate);
            InstantiateFlowerBadge();
            SpawnRate = Time.time + 60;

        }
    }

    void InstantiateFlowerBadge()
    {
        var FlowerX = Random.Range(FlowerBadgeMinX, FlowerBadgeMaxX);
        var FlowerY = Random.Range(FlowerBadgeMinY, FlowerBadgeMaxY);
        Instantiate(Flower, transform.position + new Vector3(FlowerX, FlowerY, 0), transform.rotation);
    }
}

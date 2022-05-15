using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    List<GameObject> ObstacleList = new List<GameObject>();
    public GameObject obstacle;
    public GameObject duckObstacle;
    public float maxX;
    public float minX;
    public float timeBetweenSpawn;
    private float spawnTime;

    private void Start()
    {
        LoadObstacles();
    }


    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);

        Instantiate(obstacle, transform.position + new Vector3(randomX, -4, 0), transform.rotation);
    }

    void LoadObstacles()
    {
        ObstacleList.Add(obstacle);
        ObstacleList.Add(duckObstacle);
    }
}

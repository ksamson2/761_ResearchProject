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

    public float NormalCloudRate;
    public int timeBetweenSpawn;
    public int TimeBetweenSpawnEndRate;
    public float SpacingBetweenClouds;
    private float IncreaseCloudSize = 0.01f;
    public List<SpawnObstacles.Obstacles> NormalClouds;
    public int CurrentCloudIndex = 0;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (Time.time > SpawnRate)
        {
            InstantiateFlowerBadge();
            SpawnRate = Time.time + 60;

        }
        if (SpawnObstacles.ShouldSpawnObstacles)
        {
            if (Time.time > NormalCloudRate && Time.time < SpawnObstacles.BreathingCloudsSpawnRate - 10)
            {
                SpawnNormalClouds();
                NormalCloudRate = Time.time + Random.Range(timeBetweenSpawn, TimeBetweenSpawnEndRate);
            }
        }
    }

void InstantiateFlowerBadge()
    {
        var FlowerX = Random.Range(FlowerBadgeMinX, FlowerBadgeMaxX);
        var FlowerY = Random.Range(FlowerBadgeMinY, FlowerBadgeMaxY);
        Instantiate(Flower, transform.position + new Vector3(FlowerX, FlowerY, 0), transform.rotation);
    }
    void SpawnNormalClouds()
    {
        float xposition = 5;
        var CurrentCloud = NormalClouds[CurrentCloudIndex];
        var cloudSpawnX = xposition + 1 * SpacingBetweenClouds +(IncreaseCloudSize * 100);
        var cloudSpawnY = Random.Range(CurrentCloud.MinimumY, CurrentCloud.MaximumY);

        Vector3 SpawnPosition = new Vector3(cloudSpawnX, cloudSpawnY, 0);
        Instantiate(CurrentCloud.GameObject, transform.position + new Vector3(cloudSpawnX, cloudSpawnY, 0), transform.rotation);

    }
}

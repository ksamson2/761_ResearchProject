using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [System.Serializable]
    public class Obstacles
    {
        public GameObject GameObject;
        public float MinimumY;
        public float MaximumY;
    }

    [System.Serializable]
    public class BubbleObject
    {
        public float MaximumY;
        public float MinimumY;
        public float MaximumX;
        public float MinimumX;
        public float TimeBetweenSpawn;
        public float SpawnRate;
    }

    public static int ObstaclesUnlockedTotal = 2;
    public static int ObstaclesToUnlockMax = 2;

    public List<BreathingExerciseClouds> BreathingClouds;
    public List<Obstacles> ObstacleObjects;

    public GameObject Marshmallow;
    public BubbleObject Bubble;
    public float xSpawnRange;
    public float minXSpawnRange;

    public float timeBetweenSpawn;
    public float TimeBetweenSpawnEndRate;
    private float spawnRate;

    public float TimeBetweenBreathingClouds;
    private float BreathingCloudsSpawnRate;
    public float SpacingBetweenMarshmallows = 1.6f;
    public float SpacingBetweenClouds = 1.5f;
    public ScoreManager ScoreManager;
    public static bool ShouldSpawnObstacles = false;

    public float IncreaseCloudSize = 0.01f;
    private void Start()
    {
        ScoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        if(ShouldSpawnObstacles)
        {
            Spawn();
        }
        
    }

    void Spawn()
    {
        float RandomX = Random.Range(minXSpawnRange, xSpawnRange);
       
        if (Time.time > spawnRate && ShouldSpawnObstacles)
        {
            SpawnRockObstacles(RandomX);
            spawnRate = Time.time + Random.Range(timeBetweenSpawn, TimeBetweenSpawnEndRate);
        }

        if (Time.time > Bubble.SpawnRate)
        {

            var BubbleY = Random.Range(Bubble.MinimumY, Bubble.MaximumY);
            var BubbleX = Random.Range(Bubble.MinimumX, Bubble.MaximumX);
            ObjectPooler.Instance.SpawnFromPool("Bubble", BubbleX, BubbleY);
            Bubble.SpawnRate = Time.time + Bubble.TimeBetweenSpawn;
        }

        if (Time.time > BreathingCloudsSpawnRate)
        {
            SpawnBreathingClouds();
            BreathingCloudsSpawnRate = Time.time + TimeBetweenBreathingClouds;
            IncreaseCloudSize += 0.01f;
        }
    }

    void SpawnRockObstacles(float RandomX)
    {
        int RandomIndex = Random.Range(0, ObstaclesUnlockedTotal);
        var ObstacleToSpawn = ObstacleObjects[RandomIndex];
        var ObstacleY = Random.Range(ObstacleToSpawn.MinimumY, ObstacleToSpawn. MaximumY);
        Instantiate(ObstacleToSpawn.GameObject, transform.position + new Vector3(RandomX, ObstacleY, 0), transform.rotation);
    }
    public void AddObstacle ()
    {
        if (ObstaclesUnlockedTotal < ObstaclesToUnlockMax)
            ObstaclesUnlockedTotal++;
    }

    void SpawnBreathingClouds()
    {
        SpacingBetweenClouds += 0.1f;

        float xposition = 2;

        for (var i = 0; i < BreathingClouds.Count; i++)
        {
            var mindfulnessObj = BreathingClouds[i];
            var cloudSpawnX = xposition + i * SpacingBetweenClouds + (IncreaseCloudSize * 100 );
            var cloudSpawnY = Random.Range(mindfulnessObj.MinimumY, mindfulnessObj.MaximumY);
            GameObject Cloud = Instantiate(mindfulnessObj.GameObject, transform.position + new Vector3(cloudSpawnX, cloudSpawnY, 0), transform.rotation);
            var CurrentCloudScale = Cloud.transform.localScale;
            Cloud.transform.localScale = new Vector3(CurrentCloudScale.x + IncreaseCloudSize, CurrentCloudScale.y + IncreaseCloudSize, CurrentCloudScale.z);
            for (int marshmallowIndex = 0; marshmallowIndex < mindfulnessObj.MarshmallowCount; marshmallowIndex++)
            {
                var marshmallowX = cloudSpawnX + (marshmallowIndex * SpacingBetweenMarshmallows) - 2;
                Instantiate(Marshmallow, transform.position + new Vector3(marshmallowX, cloudSpawnY + 2, 0), transform.rotation);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [System.Serializable]
    public class BreathingExerciseClouds
    {
        public GameObject GameObject;
        public float MinimumY;
        public float MaximumY;
        public int MarshmallowCount;
    }

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
        public GameObject GameObject;
        public float MaximumY;
        public float MinimumY;
        public float MaximumX;
        public float MinimumX;
        public float TimeBetweenSpawn;
        public float SpawnRate;
    }

    public List<BreathingExerciseClouds> BreathingClouds;
    public List<Obstacles> ObstacleObjects;

    public GameObject Marshmallow;
    public BubbleObject Bubble;
    public float xSpawnRange;
    public float minXSpawnRange;

    public float timeBetweenSpawn;
    private float spawnRate;

    public float TimeBetweenBreathingClouds;
    private float BreathingCloudsSpawnRate;
    public float SpacingBetweenMarshmallows = 1.6f;
    public float SpacingBetweenClouds = 1.5f;
    public ScoreManager ScoreManager;
    public bool ShouldSpawnObstacles = true; 
    private void Start()
    {
        // StartCoroutine(SpawnMindfulObjects());
        ScoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        float RandomX = Random.Range(minXSpawnRange, xSpawnRange);
        float currentScore = ScoreManager.score;
       
        if (Time.time > spawnRate && ShouldSpawnObstacles)
        {
            SpawnRockObstacles(RandomX);
            spawnRate = Time.time + timeBetweenSpawn;
        }

        if(Time.time > Bubble.SpawnRate)
        {
            
            var BubbleY = Random.Range(Bubble.MinimumY, Bubble.MaximumY);
            var BubbleX = Random.Range(Bubble.MinimumY, Bubble.MaximumY);
            Instantiate(Bubble.GameObject, transform.position + new Vector3(BubbleX, BubbleY, 0), transform.rotation);
            Bubble.SpawnRate = Time.time + Bubble.TimeBetweenSpawn;
        }

        if(Time.time > BreathingCloudsSpawnRate)
        {
            ShouldSpawnObstacles = false;

            for (var count = 0; count < 2; count++)
            {
                SpawnBreathingClouds();
            }
            BreathingCloudsSpawnRate = Time.time + TimeBetweenBreathingClouds; 
        } else
        {
            ShouldSpawnObstacles = true; 
        }
    }

    void SpawnRockObstacles(float RandomX)
    {
        int RandomIndex = Random.Range(0, ObstacleObjects.Count);
        var ObstacleToSpawn = ObstacleObjects[RandomIndex];
       var ObstacleY = Random.Range(ObstacleToSpawn.MinimumY, ObstacleToSpawn. MaximumY);
        Instantiate(ObstacleToSpawn.GameObject, transform.position + new Vector3(RandomX, ObstacleY, 0), transform.rotation);
    }

    void SpawnBreathingClouds()
    {
        Debug.Log("breathingclouds");
        float xposition = 2;

        for (var i = 0; i < BreathingClouds.Count; i++)
        {
            var mindfulnessObj = BreathingClouds[i];
            var cloudSpawnX = xposition + i * SpacingBetweenClouds;
            var cloudSpawnY = Random.Range(mindfulnessObj.MinimumY, mindfulnessObj.MaximumY);
            Instantiate(mindfulnessObj.GameObject, transform.position + new Vector3(cloudSpawnX, cloudSpawnY, 0), transform.rotation);
            for (int marshmallowIndex = 0; marshmallowIndex < mindfulnessObj.MarshmallowCount; marshmallowIndex++)
            {
                var marshmallowX = cloudSpawnX + (marshmallowIndex * SpacingBetweenMarshmallows) - 2;
                Instantiate(Marshmallow, transform.position + new Vector3(marshmallowX, cloudSpawnY + 2, 0), transform.rotation);
            }
        }
    }

   /* IEnumerator SpawnMindfulObjects()
    {
        float xposition = 2;
        while (true)
        {
            for (var i = 0; i < BreathingClouds.Count; i++)
            {
                var mindfulnessObj = BreathingClouds[i];
                var cloudSpawnX = xposition + i * spacingBetweenClouds;
                var cloudSpawnY = Random.Range(mindfulnessObj.MinimumY, mindfulnessObj.MaximumY);
                Instantiate(mindfulnessObj.GameObject, transform.position + new Vector3(cloudSpawnX, cloudSpawnY, 0), transform.rotation);
                for (int marshmallowIndex = 0; marshmallowIndex < mindfulnessObj.MarshmallowCount; marshmallowIndex++)
                {
                    var marshmallowX = cloudSpawnX + (marshmallowIndex * spacingBetweenMarshmallows) - 2;
                    Instantiate(Marshmallow, transform.position + new Vector3(marshmallowX, cloudSpawnY + 2, 0), transform.rotation);
                }
            }
            yield return new WaitForSeconds(46);

        }
    }*/

    //void SpawnMindfulObstacles()
    //{
    //    foreach (var mindfulobject in MindfulObjectList)
    //    {
    //        Instantiate(mindfulobject, transform.position + new Vector3(6, 0, 0), transform.rotation);
    //    }
    //    //Instantiate(mindfulobject, new Vector3(randomX, ySpawnValue, 0), Quaternion.identity);
    //    if (isMindfulnessStageActive)
    //    {
    //        CancelInvoke();
    //    }

    //}
}

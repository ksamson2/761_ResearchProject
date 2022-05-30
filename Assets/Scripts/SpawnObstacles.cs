using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [System.Serializable]
    public class MindfulnessObject
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

    public List<MindfulnessObject> MindfulnessObjects;
    public List<Obstacles> ObstacleObjects;

    public GameObject Marshmallo;
    public float xSpawnRange;
    public float minXSpawnRange;

    public float timeBetweenSpawn;
    public float mindfulSpawnRate;
    private float spawnRate;
    private bool shouldSpawnObstacles = true;
    public float spacingBetweenMarshmallows = 1.6f;
    public float spacingBetweenClouds = 1.5f;
    public ScoreManager ScoreManager;

    private void Start()
    {
        StartCoroutine(SpawnMindfulObjects());
        ScoreManager = FindObjectOfType<ScoreManager>();

    }

    void Update()
    {
        
        
        if (Time.time > spawnRate && shouldSpawnObstacles)
        {
            Spawn();
            spawnRate = Time.time + timeBetweenSpawn;
        }

    }

    void Spawn()
    {
        float RandomX = Random.Range(minXSpawnRange, xSpawnRange);
        float currentScore = ScoreManager.score;
        float CurrentTimeInSeconds = currentScore;
        if (CurrentTimeInSeconds % 46 > 19)
        {
            int RandomIndex = Random.Range(0, ObstacleObjects.Count);
            var ObstacleToSpawn = ObstacleObjects[RandomIndex];
            var ObstacleY = Random.Range(ObstacleToSpawn.MinimumY, ObstacleToSpawn.MaximumY);
            Instantiate(ObstacleToSpawn.GameObject, transform.position + new Vector3(RandomX, ObstacleY, 0), transform.rotation);
        }

    }

    IEnumerator SpawnMindfulObjects()
    {
        float xposition = 2;
        while (true)
        {
            for (var i = 0; i < MindfulnessObjects.Count; i++)
            {
                var mindfulnessObj = MindfulnessObjects[i];
                var cloudSpawnX = xposition + i * spacingBetweenClouds;
                var cloudSpawnY = Random.Range(mindfulnessObj.MinimumY, mindfulnessObj.MaximumY);
                Instantiate(mindfulnessObj.GameObject, transform.position + new Vector3(cloudSpawnX, cloudSpawnY, 0), transform.rotation);
                for (int marshmallowIndex = 0; marshmallowIndex < mindfulnessObj.MarshmallowCount; marshmallowIndex++)
                {
                    var marshmallowX = cloudSpawnX + (marshmallowIndex * spacingBetweenMarshmallows) - 2;
                    Instantiate(Marshmallo, transform.position + new Vector3(marshmallowX, cloudSpawnY + 2, 0), transform.rotation);
                }
            }
            yield return new WaitForSeconds(46);

        }
    }

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

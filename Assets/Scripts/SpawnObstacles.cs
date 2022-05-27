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

    public GameObject obstacle;
    public GameObject DuckObstacle;
    public GameObject Marshmallo;
    public float xSpawnRange;
    public float minXSpawnRange;

    public float timeBetweenSpawn;
    public float mindfulSpawnRate;
    private float mindfulCloudSpawnDelay = 4;
    private float spawnRate;
    private bool shouldSpawnObstacles = true;
    public float spacingBetweenMarshmallows = 1.6f;
    public float spacingBetweenClouds = 5f;

    private void Start()
    {
        StartCoroutine(SpawnMindfulObjects());
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

        int RandomIndex = Random.Range(0, ObstacleObjects.Count);
        var ObstacleToSpawn = ObstacleObjects[RandomIndex];
        var ObstacleY = Random.Range(ObstacleToSpawn.MinimumY, ObstacleToSpawn.MaximumY);
        Instantiate(ObstacleToSpawn.GameObject, transform.position + new Vector3(RandomX, ObstacleY, 0), transform.rotation);
    }

    IEnumerator SpawnMindfulObjects()
    {
        float xposition = 2;
        while (true)
        {
            shouldSpawnObstacles = false;

            for (var i = 0; i < MindfulnessObjects.Count; i++)
            {
                var mindfulnessObj = MindfulnessObjects[i];
                var cloudSpawnX = xposition + i * spacingBetweenClouds;
                var cloudSpawnY = Random.Range(mindfulnessObj.MinimumY, mindfulnessObj.MaximumY);
                Instantiate(mindfulnessObj.GameObject, transform.position + new Vector3(cloudSpawnX, cloudSpawnY, 0), transform.rotation);
                for (int marshmallowIndex = 0; marshmallowIndex < mindfulnessObj.MarshmallowCount; marshmallowIndex++)
                {
                    var marshmallowX = cloudSpawnX + (marshmallowIndex * spacingBetweenMarshmallows) -2; 
                    Instantiate(Marshmallo, transform.position + new Vector3(marshmallowX, cloudSpawnY + 2, 0), transform.rotation);
                }
            }

            shouldSpawnObstacles = true;

            yield return new WaitForSeconds(24);
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

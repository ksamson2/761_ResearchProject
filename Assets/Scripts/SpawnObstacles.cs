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

    public List<MindfulnessObject> MindfulnessObjects;

    public GameObject obstacle;
    public GameObject Marshmallo;
    public float xSpawnRange;
    public float minXSpawnRange;

    public float timeBetweenSpawn;
    public float mindfulSpawnRate;
    private float mindfulCloudSpawnDelay = 4;
    private float spawnRate;
    private bool shouldSpawnObstacles = true;
    public float spacingBetweenMarshmallows = 1.5f;
    public float spacingBetweenClouds = 5f;

    private void Start()
    {

        //InvokeRepeating("SpawnMindfulObstacles", beginSpawn, mindfulSpawnRate);
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
        float randomX = Random.Range(minXSpawnRange, xSpawnRange);
        Instantiate(obstacle, transform.position + new Vector3(randomX, -4, 0), transform.rotation);
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
                    Instantiate(Marshmallo, transform.position + new Vector3(cloudSpawnX + marshmallowIndex * spacingBetweenMarshmallows, cloudSpawnY + 2, 0), transform.rotation);
                }
            }

            shouldSpawnObstacles = true;

            yield return new WaitForSeconds(16);
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

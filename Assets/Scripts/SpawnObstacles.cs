using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    List<GameObject> MindfulObjectList = new List<GameObject>();
    public GameObject obstacle;
    public GameObject InhaleCloud;
    public GameObject ExhaleCloud;
    public GameObject Marshmallo;
    public float xSpawnRange;
    public float minXSpawnRange;
    public float ySpawnValue;
    public float timeBetweenSpawn;
    public float mindfulSpawnRate;
    private float mindfulCloudSpawnDelay = 4;
    private float spawnRate;
    private bool shouldSpawnObstacles = true;

    private void Start()
    {
        LoadObstacles();
        //InvokeRepeating("SpawnMindfulObstacles", beginSpawn, mindfulSpawnRate);
        StartCoroutine(SpawnMindfulObjects());
    }

    void Update()
    {
        if (Time.time > spawnRate && shouldSpawnObstacles)
        {
            // Spawn();
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

            Instantiate(MindfulObjectList[0], transform.position + new Vector3(xposition, ySpawnValue, 0), transform.rotation);
            for (int i = 0; i < 4; i++)
            {
                Instantiate(Marshmallo, transform.position + new Vector3(xposition + i  , ySpawnValue - 4 , 0), transform.rotation);
            }
            yield return new WaitForSeconds(mindfulCloudSpawnDelay);

            Instantiate(MindfulObjectList[1], transform.position + new Vector3(xposition, ySpawnValue - 4, 0), transform.rotation);
            yield return new WaitForSeconds(mindfulCloudSpawnDelay);

            Instantiate(MindfulObjectList[2], transform.position + new Vector3(xposition, ySpawnValue, 0), transform.rotation);
            yield return new WaitForSeconds(mindfulCloudSpawnDelay);

            shouldSpawnObstacles = true;
            yield return new WaitForSeconds(mindfulSpawnRate);
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

    void LoadObstacles()
    {
        MindfulObjectList.Add(InhaleCloud);
        MindfulObjectList.Add(ExhaleCloud);
        MindfulObjectList.Add(InhaleCloud);
    }
}

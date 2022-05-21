using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    List<GameObject> MindfulObjectList = new List<GameObject>();
    public GameObject obstacle;
    public GameObject InhaleCloud;
    public GameObject ExhaleCloud;
    public float xSpawnRange;
    public float minXSpawnRange;
    public float ySpawnValue;
    public float timeBetweenSpawn;
    public float mindfulSpawnRate;
    private float beginSpawn = 4.0f;
    private float spawnRate;
    // public float spawnDelay;
    private bool isMindfulnessStageActive = false;
    private void Start()
    {
        LoadObstacles();
        InvokeRepeating("SpawnMindfulObstacles", beginSpawn, mindfulSpawnRate);
        //StartCoroutine(SpawnMindfulObjects());
    }


    void Update()
    {
        if (Time.time > spawnRate)
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

    //IEnumerator SpawnMindfulObjects()
    //{
    //    while(isMindfulnessStageActive)
    //    {
    //        foreach (var mindfulobject in MindfulObjectList)
    //        {
    //            /*instantiate(mindfulobject, new vector3(random.range(-xspawnrange, xspawnrange), yspawnvalue, 0), quaternion.identity);*/
    //        }
    //        Instantiate(InhaleCloud, new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawnValue, 0), Quaternion.identity);


    //        yield return new WaitForSeconds(mindfulSpawnRate);
    //    }
    //}


    void SpawnMindfulObstacles()
    {
        float randomX = Random.Range(minXSpawnRange, xSpawnRange);


        foreach (var mindfulobject in MindfulObjectList)
        {
            Instantiate(mindfulobject, transform.position + new Vector3(randomX, 0, 0), transform.rotation);
        }
        //Instantiate(mindfulobject, new Vector3(randomX, ySpawnValue, 0), Quaternion.identity);
        if (isMindfulnessStageActive)
        {
            CancelInvoke();
        }
    }

    void LoadObstacles()
    {
        MindfulObjectList.Add(InhaleCloud);
        MindfulObjectList.Add(ExhaleCloud);
    }
}

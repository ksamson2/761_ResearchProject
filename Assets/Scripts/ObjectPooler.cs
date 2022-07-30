using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool {
        public string Tag;
        public int Size;
        public GameObject Prefab;
    }

    public List<Pool> Pools;
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    void Start()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        
        foreach (Pool Pool in Pools)
        {
            Queue<GameObject> ObjectPool = new Queue<GameObject>();
            for(int i = 0; i < Pool.Size; i++)
            {
                GameObject Object = Instantiate(Pool.Prefab);
                Object.SetActive(false);
                ObjectPool.Enqueue(Object);
            }

            PoolDictionary.Add(Pool.Tag, ObjectPool);
        }
    }

    public static ObjectPooler Instance;

    private void Awake()
    {
       Instance = this;
    }

    public GameObject SpawnFromPool(string Tag, float XCoordinate, float YCoordinate)
    {
        if(!PoolDictionary.ContainsKey(Tag))
        {
            Debug.Log("Pool with tag " + Tag + " doesn't exist");
            return null;
        }
        GameObject ObjectToSpawn = PoolDictionary[Tag].Dequeue();

        ObjectToSpawn.SetActive(true);
        ObjectToSpawn.transform.position = transform.position + new Vector3(XCoordinate, YCoordinate, 0);

        PoolDictionary[Tag].Enqueue(ObjectToSpawn);

        return ObjectToSpawn;
    }
    
}
 
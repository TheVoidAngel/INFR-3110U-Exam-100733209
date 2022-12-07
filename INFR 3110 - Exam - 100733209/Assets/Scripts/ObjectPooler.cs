using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler instance;
    public List<Pool> pools;
    Queue<GameObject> objectPool;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach(Pool pool in pools)
        {
            objectPool = new Queue<GameObject>();

            for(int i = 0; i < pool.size; i++)
            {
                GameObject objects = Instantiate(pool.prefab);
                objects.SetActive(false);
                objectPool.Enqueue(objects);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject Spawn(string tag, Vector3 position)
    {
        GameObject ghost = poolDictionary[tag].Dequeue();

        ghost.SetActive(true);
        ghost.transform.position = position;

        poolDictionary[tag].Enqueue(ghost);

        return ghost;
    }
}

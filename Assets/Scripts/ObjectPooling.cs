using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;

    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    public static int x=0;
    public int StartPos=50;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        pooledObjects = new List<GameObject>();
        x = 0;
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            x = x + StartPos;
            obj.transform.position = new Vector3(x, 0, 0);
            obj.SetActive(true);
            pooledObjects.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}

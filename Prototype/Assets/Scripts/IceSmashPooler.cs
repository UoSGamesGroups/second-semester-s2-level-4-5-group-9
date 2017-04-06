using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSmashPooler : MonoBehaviour {

    // Generic Object Pooling Script

    public static IceSmashPooler current;
    [Space(5), Tooltip("Object to be Pooled")]
    public GameObject pooledObject;
    [Space(5), Tooltip("Amount Pooled at Start")]
    public int pooledAmount = 20;
    [Space(5), Tooltip("willGrow allows objects to be instantied if none are currently ready in the pool")]
    public bool willGrow = true;

    List<GameObject> pooledObjects;

    void Awake()
    {
        current = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
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

        // Instantiates obj if there are none ready in the pool
        // if willGrow is enabled.
        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj;
        }

        return null;
    }
}

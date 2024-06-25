using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSystem : MonoBehaviour
{
    // Singleton Script
    public static PoolSystem Instance { get; private set; }
    private List<GameObject> pool = new List<GameObject>();

    [Header("Pool Configs")]
    // Prefab Object
    [SerializeField] [Tooltip("Prefab Object.")] private GameObject pooledObject;
    // Maximum of pool objects
    [SerializeField] [Tooltip("Maximum of pool objects.")] private int maxObjects;
    // Time for object auto destroy
    [SerializeField] [Tooltip("Time for object auto disable.")] private float timeToAutoDisable;
    // True as default, if the maximum has been reached, instantiate to prevent errors
    [SerializeField] [Tooltip("True as default, if the maximum has been reached, instantiate to prevent errors.")] private bool ignoreMax = true;

    // If has to be a singleton
    [SerializeField] [Tooltip("If has to be a singleton.")] private bool isSingleton = true;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else if(isSingleton)
        {
            Instance = this;
        }

        for (int i = 0; i < maxObjects; i++) // Looping to generate objects
        {
            // Generate a pool and put in a position far to prevend collider frame bug
            var poolObject = Instantiate(pooledObject,new Vector3(-500,-500,-500),pooledObject.transform.rotation);
            poolObject.AddComponent<PooledObject>();
            poolObject.SetActive(false);
            pool.Add(poolObject);
        }
    }
    #region TakeFromPool
    // Take a object from pool
    public void TakeFromPool()
    {
        foreach(GameObject pg in pool)
        {
            if(pg.activeSelf == false) // Verify in list who is disable to take
            {
                pg.transform.position = pooledObject.transform.position;
                pg.transform.rotation = pooledObject.transform.rotation;
                pg.SetActive(true);
                pg.GetComponent<PooledObject>().ReturnToPool(timeToAutoDisable);
                return;
            }
        }
        // if pass the maximum of the list
        if(ignoreMax)
        {
            var poolObject = Instantiate(pooledObject,pooledObject.transform.position,pooledObject.transform.rotation);
            poolObject.AddComponent<PooledObject>();
            poolObject.GetComponent<PooledObject>().AutoDestroy(timeToAutoDisable);
        }
    }
    // Take a object from pool with postition
    public void TakeFromPool(Transform spawnPosition)
    {
        foreach(GameObject pg in pool)
        {
            if(pg.activeSelf == false) // Verify in list who is disable to take
            {
                pg.transform.position = spawnPosition.position;
                pg.transform.rotation = pooledObject.transform.rotation;
                pg.SetActive(true);
                pg.GetComponent<PooledObject>().ReturnToPool(timeToAutoDisable);
                // put auto destroy
                return;
            }
        }
        // if pass the maximum of the list
        if(ignoreMax)
        {
            var poolObject = Instantiate(pooledObject,spawnPosition.position,pooledObject.transform.rotation);
            poolObject.AddComponent<PooledObject>();
            poolObject.GetComponent<PooledObject>().AutoDestroy(timeToAutoDisable);
        }    
    }
    // Take a object from pool with postition and rotation
    public void TakeFromPool(Transform spawnPosition, Quaternion rotation)
    {
        foreach(GameObject pg in pool)
        {
            if(pg.activeSelf == false) // Verify in list who is disable to take
            {
                pg.transform.position = spawnPosition.position;
                pg.transform.rotation = rotation;
                pg.SetActive(true);
                pg.GetComponent<PooledObject>().ReturnToPool(timeToAutoDisable);
                return;
            }
        }
        if(ignoreMax)
        {
            var poolObject = Instantiate(pooledObject,spawnPosition.position,rotation);
            poolObject.AddComponent<PooledObject>();
            poolObject.GetComponent<PooledObject>().AutoDestroy(timeToAutoDisable);
        }  
    }
    #endregion
}

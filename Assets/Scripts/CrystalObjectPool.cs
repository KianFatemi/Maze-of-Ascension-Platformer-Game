using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CrystalObjectPool : MonoBehaviour
{
    public static CrystalObjectPool instance;
    GameObject[] pooledCrystals;
    [SerializeField] 
    GameObject crystalToPool;
    [SerializeField, Range(1, 100)]
    int maxPooledCrystals;
    [SerializeField]
    Transform[] spawner;
    

    void Start()
    {
        pooledCrystals = new GameObject[maxPooledCrystals];

        for(int i = 0; i < maxPooledCrystals; i++) //create pooled crytals and put them into array
        {
            GameObject tempObj = Instantiate(crystalToPool);
            pooledCrystals[i] = tempObj;
            pooledCrystals[i].SetActive(false);
        }

        SpawnCrystal(); //start spawning

    }
    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
 
    GameObject GetPooledCrystal()
    {
        foreach(GameObject pooledCrystal in pooledCrystals) //loop to find inactive crystals
        {
            if (!pooledCrystal.activeInHierarchy)
            {
                pooledCrystal.SetActive(true);
                return pooledCrystal;
            }
        }
        
        return null;
    }

    void SpawnCrystal()
    {
        for (int i = 0; i < spawner.Length; i++)
        {
            SpawnPooledObject(spawner[i]);
        }
    }

   void SpawnPooledObject(Transform spawnPosition)
    {
       GameObject pooledCrystals = GetPooledCrystal(); //grab a crystal from the pool
       
       if (pooledCrystals != null)
       {
            pooledCrystals.transform.position = spawnPosition.position;

            

        }
    }

}

using UnityEngine;

public class PlatformsManager : MonoBehaviour
{
   [SerializeField]
   private Transform platformsPivot;
   [SerializeField]
    private InstantiatePoolObjects[] platformPrefabs;
    [SerializeField]
    private InstantiatePoolObjects[]securePlataformPrefabs;
    [SerializeField]
    private int initialPlatforms = 5;
    [SerializeField]
    private float speed = 5f;
    private bool isRunning = true;
    private GameObject lastPlatform;
    private int platformsInstantiated = 0 ;
    public void StartGame()
    {
        lastPlatform = null;
        platformsInstantiated = 0; 
        initializePlatforms();
        InstantiatePlatform(initialPlatforms);
        transform.position = platformsPivot.position;
        isRunning = true;
    }
    public void initializePlatforms()
    {
        foreach (var platform in platformPrefabs)
        {
            platform.DeactivateAllObjects();
        }
        foreach(var securePlataform in securePlataformPrefabs)
        {
            securePlataform.DeactivateAllObjects();
        }
    }
    public void InstantiatePlatform(int number)
    {
        for (int i=  0; i < number; i++)
        {
            InstantiatePoolObjects instantiatePool = platformPrefabs[Random.Range(0,platformPrefabs.Length)];
            if(platformsInstantiated < 2)
            {
                instantiatePool = securePlataformPrefabs[Random.Range(0, platformPrefabs.Length)];
            }else
            {
                instantiatePool = platformPrefabs[Random.Range(0, platformPrefabs.Length)];
            }          
            platformsInstantiated++;
            Vector3 spawnPosition = Vector3.zero;
            if (lastPlatform !=null)
            {
                spawnPosition = lastPlatform.transform.localPosition + lastPlatform.GetComponent<Collider>().bounds.size.z*Vector3.forward * 0.5f;
            }
            instantiatePool.InstantiateObject(spawnPosition);
            GameObject newPlatform = instantiatePool.GetCurrentObject();
            newPlatform.transform.SetParent(transform);
            newPlatform.transform.localPosition = spawnPosition + newPlatform.GetComponent<Collider>().bounds.size.z * Vector3.forward * 0.5F;
            lastPlatform = newPlatform;
        }
    }
    private void Update()
    {
    if (isRunning)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }    
    }
    public void StopPlatforms()
    {
        isRunning = false;
    }
}
using UnityEngine;

public class PlatformsManager : MonoBehaviour
{
    [SerializeField]
    private Transform platformsPrivot;
    [SerializeField]
    private GameObject[] platformsPrefabs;
    [SerializeField]
    private int initialPlatform = 5;
    [SerializeField]
    private float speed = 5f;
    private bool isRunning = true;
    private GameObject lastPlatform;
    private void Start()
    {
        InstantiatePlatform(initialPlatform);
        transform.position = plataformsPrivot.position;
    }
    public void InstantiatePlatform(int number)
    {
        for (int i = 0; i < number; i++)
        {
            
        GameObject platfomPrefab = platfomPrefabs[Random.Range(0, platafomPrefabs.Length)];
        Vector3 spawPosition = Vector3.zero;
        if (lastPlatform != null)
        {
            spawPosition = lastPlatform.transform.lastPlatformPosition + lastPlatform.GetComponent<Collider>().bonuds.size.z * Vector3.forward * 0.5f;
        }
        GameObject newPlatform = Instantiate(platformPrefab, Vector3.zero, Quaternion.identity, transform);
        newPlatform.transform.localPosition = spawnPosition + newPlatform.GetComponent<Collider>().bounds.size.z * Vector3.forward * 0.5f;
        lastPlatform = newPlatform;
        }
    }
    private void Update()
    {
        if (isRunning)
        {
            plataformsPrivot.Translate(Vector3.back * speed * Time.deltaTime);
        
        }
    }
}

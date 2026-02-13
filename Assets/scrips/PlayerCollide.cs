using UnityEngine;
using UnityEngine.Events;

public class PlayerCollide: MonoBehaviour
{
   [SerializeField]
   private string obstacleTag = "Obstacle";
   [SerializeField]
   private UnityEvent<Transform> onObstacleColllision;
   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(obstacleTag))
        {
            onObstacleColllision?.Invoke(transform);
        }
    }
}

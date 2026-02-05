using UnityEngine;
using UnityEngine.Events;

public class PlatformsLimit : MonoBehaviour
{
   [SerializeField]
   private string plataformsTag = "Gruond";
   [SerializeField]
   private UnityEvent onPlataformDetected;
   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(plataformsTag))
        {
            other.gameObject.SetActive(false);
            onPlataformDetected?.Invoke();
        }
    }
}

using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    Vector3 rotationSpeed = new Vector3(0f,0f,0f);
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}

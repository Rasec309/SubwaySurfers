using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private GameObject[] coins;
    private void OnEnable()
    {
        ActivateCoin();
    }
    private void ActivateCoin()
    {
        foreach (var coin in coins)
        {
            coin.SetActive(true);
        }
    }
}

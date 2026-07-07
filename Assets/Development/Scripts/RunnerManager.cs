using UnityEngine;

public class RunnerManager : MonoBehaviour
{
    [SerializeField] private GameObject spawnPrefab;
    private float targetZValue = 0;

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(spawnPrefab, new Vector3(0, 0, targetZValue), Quaternion.identity);
            targetZValue += 50;
        }
    }
}


using UnityEngine;
using System.Collections.Generic;

public class GroundPiece : MonoBehaviour
{
    [SerializeField] private Transform[] positions;
    [SerializeField] private GameObject cheesePrefab;
    [SerializeField] private List<GameObject> obstaclePrefabs;

    private GameObject spawnedItems;

    private int _randomIndex;
    private void Start()
    {
        GenericPosition();
    }

    public void GenericPosition()
    {
        _randomIndex = Random.Range(0, positions.Length);
        GenericItem();
    }

    private void GenericItem()
    {
        int randomItemIndex = UnityEngine.Random.Range(0, 16);
        if (randomItemIndex < 1)
        {
            return;
        }
        else if (randomItemIndex >= 1 && randomItemIndex < 10)
        {
            spawnedItems = Instantiate(cheesePrefab, positions[_randomIndex].position, Quaternion.identity);
        }
        else if (randomItemIndex >= 10 && randomItemIndex < 16)
        {
            int randomObstacleIndex = Random.Range(0, obstaclePrefabs.Count);
            spawnedItems = Instantiate(obstaclePrefabs[randomObstacleIndex], positions[_randomIndex].position, Quaternion.identity);
        }
    }
    public void ClearItems()
    {
        if (spawnedItems != null)
        {
            Destroy(spawnedItems);
        }
    }
}


using System.Collections;
using UnityEngine;

public class GroundSpawn : MonoBehaviour
{
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private Transform fullGroundTransform;

    private bool _isTriggerable = true;

    private void OnTriggerEnter(Collider other)
    {
        if (_isTriggerable)
        {
            _isTriggerable = false;
            if (other.GetComponent<MouseyScript>())
            {
                StartCoroutine(SpawnCoroutine());
            }
        }
    }

    private IEnumerator SpawnCoroutine()
    {
        GroundPiece[] allGroundPieces = fullGroundTransform?.GetComponentsInChildren<GroundPiece>();
        yield return new WaitForSeconds(15);

        Vector3 desiredPosition = fullGroundTransform.position + new Vector3(0, 0, 500);
        fullGroundTransform.position = desiredPosition;
        _isTriggerable = true;
        foreach (var currentPiece in allGroundPieces)
        {
            currentPiece.ClearItems();
            currentPiece.GenericPosition();
        }
    }
}
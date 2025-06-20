using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private Resource resource;
    [SerializeField] private float spawnRadius = 20f;
    [SerializeField] private int initialSpawnAmount = 10;
    
    public float SpawnInterval = 5f;

    private void Start()
    {
        for (var i = 0; i < initialSpawnAmount; i++) SpawnResource();
        StartCoroutine(SpawnResourceCoroutine());
    }

    private void SpawnResource()
    {
        var randomPosition = Random.insideUnitCircle * spawnRadius;
        var spawnPosition = transform.position + new Vector3(randomPosition.x, 0, randomPosition.y);
        Instantiate(resource, spawnPosition, Quaternion.identity, transform);
    }

    private IEnumerator SpawnResourceCoroutine()
    {
        yield return new WaitForSeconds(SpawnInterval);
        SpawnResource();
        StartCoroutine(SpawnResourceCoroutine());
    }
}

using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private Resource resource;
    [SerializeField] private int spawnRadius = 20;
    [SerializeField] private int initialSpawnAmount = 10;
    [SerializeField] private int spawnInterval = 5;

    private void Start()
    {
        for (var i = 0; i < initialSpawnAmount; i++) SpawnResource();
        InvokeRepeating(nameof(SpawnResource), spawnInterval, spawnInterval);
    }

    private void SpawnResource()
    {
        var randomPosition = Random.insideUnitCircle * spawnRadius;
        var spawnPosition = transform.position + new Vector3(randomPosition.x, 0, randomPosition.y);
        Instantiate(resource, spawnPosition, Quaternion.identity);
    }
}

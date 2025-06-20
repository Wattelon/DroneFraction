using UnityEngine;

public class ResourceSpawnIntervalInput : MonoBehaviour
{
    [SerializeField] private ResourceSpawner resourceSpawner;

    public void SetInterval(string input)
    {
        if (float.TryParse(input, out var interval))
        {
            resourceSpawner.SpawnInterval = interval;
        }
    }
}

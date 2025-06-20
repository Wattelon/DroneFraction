using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Faction faction;
    [SerializeField] private Drone dronePrefab;
    [SerializeField][Range(1, 5)] private int droneAmount = 3;
    [SerializeField][Range(0, 10)] private float droneSpeed = 5;
    [SerializeField] private int resources;
    
    private List<Drone> _drones = new();
    
    public event Action ResourcesChanged;
    public Faction Faction => faction;
    public Drone UnloadingDrone;
    
    public int Resources
    {
        get => resources;
        set
        {
            resources = value;
            ResourcesChanged?.Invoke();
        }
    }

    private void Start()
    {
        for (var i = 0; i < droneAmount; i++)
        {
            SpawnDrone();
        }
    }

    public void ChangeDroneSpeed(float speed)
    {
        droneSpeed = speed;
        foreach (var drone in _drones)
        {
            drone.NavMeshAgent.speed = droneSpeed;
        }
    }

    public void ChangeDroneAmount(float amount)
    {
        while (droneAmount != (int)amount)
        {
            if (droneAmount < amount)
            {
                SpawnDrone();
                droneAmount++;
            }
            else if (droneAmount > amount)
            {
                Destroy(_drones[^1].gameObject);
                _drones.RemoveAt(_drones.Count - 1);
                droneAmount--;
            }
        }
    }

    private void SpawnDrone()
    {
        var drone = Instantiate(dronePrefab, transform.position, Quaternion.identity);
        drone.Faction = faction;
        drone.GetComponent<Renderer>().SetMaterials(GetComponent<Renderer>().sharedMaterials.ToList());
        _drones.Add(drone);
    }
}

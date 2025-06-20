using System;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Faction faction;
    [SerializeField] private int resources;
    
    public event Action ResourcesChanged;
    public Faction Faction => faction;
    
    public int Resources
    {
        get => resources;
        set
        {
            resources = value;
            ResourcesChanged?.Invoke();
        }
    }
}

using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Faction faction;
    [SerializeField] private int resources;
    
    public Faction Faction => faction;

    public void Collect(int carriedResources)
    {
        resources += carriedResources;
    }
}

using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private int value;

    public Drone CollectingDrone;

    public int Collect()
    {
        Destroy(gameObject);
        return value;
    }
}

using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private int value;

    public Drone CollectingDrone;

    public int Collect()
    {
        gameObject.SetActive(false);
        return value;
    }
}

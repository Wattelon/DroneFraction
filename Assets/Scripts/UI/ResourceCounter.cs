using System.Linq;
using TMPro;
using UnityEngine;

public class ResourceCounter : MonoBehaviour
{
    [SerializeField] private Base[] bases;
    
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        foreach (var b in bases)
        {
            b.ResourcesChanged += OnResourcesChanged;
        }
    }

    private void OnResourcesChanged()
    {
        var resources = bases.Sum(b => b.Resources);
        _text.text = $" : {resources}";
    }
}

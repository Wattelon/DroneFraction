using System.Globalization;
using TMPro;
using UnityEngine;

public class SliderText : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void SetSliderText(float value)
    {
        _text.text = value.ToString(CultureInfo.InvariantCulture);
    }
}

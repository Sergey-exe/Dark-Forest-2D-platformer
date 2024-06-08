using TMPro;
using UnityEngine;

public class TextBar : MonoBehaviour
{
    [SerializeField] private Indicators _indicators;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _indicators.ChangeHealth += ChangeText;

    }

    private void OnDisable()
    {
        _indicators.ChangeHealth -= ChangeText;
    }

    private void ChangeText()
    {
        float health;

        health = _indicators.Health;

        _text.text = $"{health}/{_indicators.MaxHealth}";
    }
}

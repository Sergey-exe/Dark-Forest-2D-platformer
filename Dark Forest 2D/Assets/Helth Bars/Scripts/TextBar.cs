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

        if (health < 0)
            health = 0;
        else if (health > _indicators.MaxHealth)
            health = _indicators.MaxHealth;

        _text.text = $"{health}/{_indicators.MaxHealth}";
    }
}

using UnityEngine;
using UnityEngine.UI;

public class HealthBar : AbstractHealthBar
{
    public override void ChangedBar()
    {
        float maxPercent = 100;
        float percentHealth;

        percentHealth = Indicators.Health * maxPercent / Indicators.MaxHealth;
        percentHealth = Mathf.Round(percentHealth);

        Text.text = $"{percentHealth}%/{maxPercent}%";
        Bar.value = percentHealth;
    }
}
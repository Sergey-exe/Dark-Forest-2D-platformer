using UnityEngine;
using UnityEngine.UI;

public class HealthBar : AbstractHealthBar
{
    public override void ChangeBar()
    {
        float maxPercent = 100;
        float percentHealth;

        percentHealth = Indicators.Health * maxPercent / Indicators.MaxHealth;
        percentHealth = Mathf.Round(percentHealth);

        if (percentHealth < 0 )
            percentHealth = 0;
        else if (percentHealth > maxPercent)
            percentHealth = maxPercent;

        Text.text = $"{percentHealth}%/{maxPercent}%";
        Slider.value = percentHealth;
    }
}

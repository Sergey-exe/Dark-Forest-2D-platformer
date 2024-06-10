using UnityEngine;
using UnityEngine.UI;

public class StandardHealthBar : HealthBar
{
    public override void ChangeBar()
    {
        float maxPercent = 100;
        float percentHealth;

        percentHealth = Health.GetHealth * maxPercent / Health.MaxHealth;
        percentHealth = Mathf.Round(percentHealth);

        Text.text = $"{percentHealth}%";
        Bar.value = percentHealth;
    }
}

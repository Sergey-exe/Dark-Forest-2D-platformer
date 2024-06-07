using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : AbstractHealthBar
{
    private const int Factor = 20;

    public override void ChangeBar()
    {
        float speedBar = 0.0001f;

        if (Coroutine != null)
            StopCoroutine(Coroutine);

        Coroutine = StartCoroutine(SmoothlyChangeHealthBar(speedBar));
    }

    private IEnumerator SmoothlyChangeHealthBar(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        float maxPercent = 100;
        float percentHealth;

        percentHealth = Indicators.Health * maxPercent / Indicators.MaxHealth;
        percentHealth = Mathf.Round(percentHealth);

        if (percentHealth < 0)
            percentHealth = 0;
        else if (percentHealth > maxPercent)
            percentHealth = maxPercent;


        Text.text = $"{percentHealth}%/{maxPercent}%";

        while (Slider.value != percentHealth)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, percentHealth, Factor * Time.deltaTime);

            yield return wait;
        }
    }
}

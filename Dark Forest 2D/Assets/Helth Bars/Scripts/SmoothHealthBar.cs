using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : AbstractHealthBar
{
    private const int Factor = 20;

    private Coroutine _coroutine;

    public override void ChangedBar()
    {
        float speedBar = 0.0001f;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SmoothlyChangeHealthBar(speedBar));
    }

    private IEnumerator SmoothlyChangeHealthBar(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        float maxPercent = 100;
        float percentHealth;

        percentHealth = Indicators.Health * maxPercent / Indicators.MaxHealth;
        percentHealth = Mathf.Round(percentHealth);

        Text.text = $"{percentHealth}%/{maxPercent}%";

        while (Bar.value != percentHealth)
        {
            Bar.value = Mathf.MoveTowards(Bar.value, percentHealth, Factor * Time.deltaTime);

            yield return wait;
        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : HealthBar
{
    private const int Factor = 20;

    private Coroutine _coroutine;

    private void LateUpdate()
    {
        
    }

    public override void ChangeBar()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SmoothlyChangeHealthBar());
    }

    private IEnumerator SmoothlyChangeHealthBar()
    {
        float maxPercent = 100;
        float percentHealth;

        percentHealth = Indicators.Health * maxPercent / Indicators.MaxHealth;
        percentHealth = Mathf.Round(percentHealth);

        Text.text = $"{percentHealth}%/{maxPercent}%";

        while (Bar.value != percentHealth)
        {
            Bar.value = Mathf.MoveTowards(Bar.value, percentHealth, Factor * Time.deltaTime);

            yield return null;
        }
    }
}

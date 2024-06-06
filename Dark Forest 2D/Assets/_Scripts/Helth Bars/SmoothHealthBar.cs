using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : MonoBehaviour
{
    private const int Factor = 20;

    [SerializeField] private Slider _slider;
    [SerializeField] private Indicators _indicators;
    [SerializeField] private TextMeshProUGUI _text;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _indicators.ChangeHealth += ChangeBar;

    }

    private void OnDisable()
    {
        _indicators.ChangeHealth -= ChangeBar;
    }

    private void ChangeBar()
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

        percentHealth = _indicators.Health * maxPercent / _indicators.MaxHealth;
        percentHealth = Mathf.Round(percentHealth);

        if (percentHealth < 0)
            percentHealth = 0;
        else if (percentHealth > maxPercent)
            percentHealth = maxPercent;


        _text.text = $"{percentHealth}%/{maxPercent}%";

        while (_slider.value != percentHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, percentHealth, Factor * Time.deltaTime);

            yield return wait;
        }
    }
}

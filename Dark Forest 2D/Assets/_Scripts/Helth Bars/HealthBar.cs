using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Indicators _indicators;
    [SerializeField] private TextMeshProUGUI _text;

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
        float maxPercent = 100;
        float percentHealth;

        percentHealth = _indicators.Health * maxPercent / _indicators.MaxHealth;
        percentHealth = Mathf.Round(percentHealth);

        if (percentHealth < 0 )
            percentHealth = 0;
        else if (percentHealth > maxPercent)
            percentHealth = maxPercent;

        _text.text = $"{percentHealth}%/{maxPercent}%";
        _slider.value = percentHealth;
    }
}

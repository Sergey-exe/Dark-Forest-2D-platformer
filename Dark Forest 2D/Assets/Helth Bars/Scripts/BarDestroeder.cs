using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarDestroyer : MonoBehaviour
{
    [SerializeField] private Indicators _indicators;
    [SerializeField] private Canvas _canvas;

    private void OnEnable()
    {
        _indicators.IsDeaded += DestroyBar;
    }

    private void OnDisable()
    {
        _indicators.IsDeaded -= DestroyBar;
    }

    private void DestroyBar()
    {
        Destroy(_canvas.gameObject);
    }
}

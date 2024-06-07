using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public abstract class AbstractHealthBar : MonoBehaviour
{
    [SerializeField] protected Indicators Indicators;
    [SerializeField] protected TextMeshProUGUI Text;

    protected Slider Slider;
    protected Coroutine Coroutine;

    private void OnEnable()
    {
        Indicators.ChangeHealth += ChangeBar;

    }

    private void OnDisable()
    {
        Indicators.ChangeHealth -= ChangeBar;
    }

    private void Start()
    {
        Slider = GetComponent<Slider>();
    }

    public abstract void ChangeBar();
}
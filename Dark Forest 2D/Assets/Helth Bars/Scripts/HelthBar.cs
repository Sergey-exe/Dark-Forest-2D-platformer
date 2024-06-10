using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Indicators Indicators;
    [SerializeField] protected TextMeshProUGUI Text;

    protected Slider Bar;

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
        Bar = GetComponent<Slider>();
    }

    public abstract void ChangeBar();
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public abstract class AbstractHealthBar : MonoBehaviour
{
    [SerializeField] protected Indicators Indicators;
    [SerializeField] protected TextMeshProUGUI Text;

    public Slider Bar { get; private set; }

    private void OnEnable()
    {
        Indicators.ChangeHealth += ChangedBar;
    }

    private void OnDisable()
    {
        Indicators.ChangeHealth -= ChangedBar;
    }

    private void Start()
    {
        Bar = GetComponent<Slider>();
    }

    public abstract void ChangedBar();
}
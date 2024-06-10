using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health Health;
    [SerializeField] protected TextMeshProUGUI Text;

    protected Slider Bar;

    private void OnEnable()
    {
        Health.ChangeHealth += ChangeBar;
    }

    private void OnDisable()
    {
        Health.ChangeHealth -= ChangeBar;
    }

    private void Start()
    {
        Bar = GetComponent<Slider>();
    }

    public abstract void ChangeBar();
}

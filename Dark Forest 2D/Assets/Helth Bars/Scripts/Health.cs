using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _protection;
    [SerializeField] private float _percentProtection = 5;

    public event UnityAction IsDeaded;
    public event UnityAction ChangeHealth;

    [field: SerializeField] public float CurrentHealth { get; private set; }

    [field: SerializeField] public float MaxHealth { get; private set; }

    [field: SerializeField] public float Level { get; private set; }

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        int percent = 100;

        float finalDamage = damage - (_protection / percent * _percentProtection);

        CurrentHealth -= finalDamage;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        ChangeHealth?.Invoke();

        if (CurrentHealth <= 0)
            IsDeaded?.Invoke();
    }

    public void TakeHeal(float heal)
    {
        if (heal < 0)
            return;

        CurrentHealth += heal;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        ChangeHealth?.Invoke();
    }
}

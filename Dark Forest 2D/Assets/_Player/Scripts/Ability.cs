using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private float _timePlay;
    [SerializeField] private float _timeRecharge;
    [SerializeField] AbilityUI _ui;

    private Coroutine _coroutine;

    public bool IsActive { get; private set; }

    public bool IsRecharge { get; private set; }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
            StartAbility();
    }

    public abstract void PlayAbility();

    public void StartAbility()
    {
        if (IsActive)
            return;

        if (IsRecharge)
        {
            Debug.LogWarning("Перезарядка!"); 
            return;
        }

        IsActive = true;
        IsRecharge = true;
        _ui.ChangeButton(_timeRecharge);
        Invoke(nameof(OffAbility), _timePlay);
        Invoke(nameof(OffRecharge), _timeRecharge);
        PlayAbility();
    }

    private void OffAbility()
    {
        IsActive = false;
    }

    private void OffRecharge()
    {
        Debug.Log("Перезарядка окончена!");
        IsRecharge = false;
    }
}

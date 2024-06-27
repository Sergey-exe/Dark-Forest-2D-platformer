using System.Collections;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private float _timePlay;
    [SerializeField] private float _timeRecharge;
    [SerializeField] private AbilityUI _ui;

    private Coroutine _coroutine;

    public bool IsActive { get; private set; }

    public bool IsRecharge { get; private set; }

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
        _ui.ChangeUI(_timeRecharge);
        StartCoroutine(OffAbility(_timePlay));
        StartCoroutine(OffRecharge(_timeRecharge));
        Invoke(nameof(OffRecharge), _timeRecharge);
        PlayAbility();
    }

    private IEnumerator OffAbility(float timePlay)
    {
        yield return new WaitForSeconds(timePlay);

        IsActive = false;
    }

    private IEnumerator OffRecharge(float timeRecharge)
    {
        yield return new WaitForSeconds(timeRecharge);

        Debug.Log("Перезарядка окончена!");
        IsRecharge = false;
    }
}

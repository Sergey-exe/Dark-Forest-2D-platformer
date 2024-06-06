using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private const string Attack = nameof(Attack);

    [SerializeField] private float _damage;
    [SerializeField] private float _percentCritical = 3;
    [SerializeField] private Indicators _indicators;
    [SerializeField] private Animator _animator;

    private float _level = 1;

    private Coroutine _coroutine = null;

    private void OnEnable()
    {
        _indicators.IsDeaded += Death;
    }

    private void OnDisable()
    {
        _indicators.IsDeaded -= Death;
    }

    private void Start()
    {
        if(_indicators)
            _level = _indicators.Level;
    }

    private float DamageStandard()
    {
        int criticalChance = Random.Range(0, 1);
        int percent = 100;
        float damage = _damage + (_percentCritical * (_damage / percent) * criticalChance) + (1 + _level); ;

        return damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Indicators>())
            _coroutine = StartCoroutine(Assault(collision.GetComponent<Indicators>()));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator Assault(Indicators indicators, float delay = 1.3f)
    {
        var whit = new WaitForSeconds(delay);

        while (indicators.Health > 0)
        {
            _animator.SetTrigger(Attack);
            indicators.TakeDamage(DamageStandard());
            yield return whit;
        }
    }

    private void Death()
    {
        Destroy(gameObject.GetComponent<EnemyAttack>());
    }
}

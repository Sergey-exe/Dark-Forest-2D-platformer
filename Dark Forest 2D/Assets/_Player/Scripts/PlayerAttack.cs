using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private const string Attack = nameof(Attack);

    [SerializeField] private float _damage;
    [SerializeField] private float _percentCritical = 3;
    [SerializeField] private int _level = 1;
    [SerializeField] private Indicators _indicators;
    [SerializeField] private Animator _animator;

    private bool _isEnemy;
    [SerializeField] private List<Indicators> _enemies;

    private void OnEnable()
    {
        _indicators.IsDead += Death;
    }

    private void OnDisable()
    {
        _indicators.IsDead -= Death;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animator.SetTrigger(Attack);

            if (_isEnemy)
                foreach (Indicators indicators in _enemies)
                    if (indicators)
                        indicators.TakeDamage(StandardDamage());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            _isEnemy = true;
            _enemies.Add(collision.GetComponent<Indicators>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            _isEnemy = false;
            _enemies.Remove(collision.GetComponent<Indicators>());
        }

    }

    private float StandardDamage()
    {
        int criticalChance = Random.Range(0, 2);
        int percent = 100;
        float damage = _damage + (_percentCritical * (_damage / percent) * criticalChance) + (1 + _level); ;

        return damage;
    }

    private void Death()
    {
        Destroy(gameObject.GetComponent<PlayerAttack>());
    }
}

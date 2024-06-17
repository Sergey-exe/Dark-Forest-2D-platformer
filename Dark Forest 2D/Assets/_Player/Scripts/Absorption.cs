using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorption : Ability
{
    [SerializeField] private Health _health;
    [SerializeField] private EnemyDetector _enemyDetector;
    [SerializeField] private float _delay;
    [SerializeField] private float _damage;

    private Coroutine _coroutine;

    public override void PlayAbility()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(nameof(DrainHealth));
    }


    private IEnumerator DrainHealth()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        List<Health> enemies;

        while (IsActive)
        {
            enemies = _enemyDetector.SearchEnemies();

            if (enemies.Count > 0)
            {
                enemies[0].TakeDamage(_damage);
                _health.TakeHeal(_damage);
            }

            yield return wait;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorption : Ability
{
    [SerializeField] private Health _health;
    [SerializeField] private EnemyDetector _enemyDetector;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private CircleShower _circleShower;
    [SerializeField] private float _delay;
    [SerializeField] private float _damage;

    private Coroutine _coroutine;

    private void Update()
    {
        if(_inputReader.DownButtonAbsorption())
            StartAbility();
    }

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
        float damage;

        _circleShower.ShowCircle(_enemyDetector.Radius);

        while (IsActive)
        {
            enemies = _enemyDetector.SearchEnemies();
            damage = _damage;

            if (enemies.Count > 0)
            {
                if (enemies[0].CurrentHealth < damage)
                    damage = enemies[0].CurrentHealth;
                
                enemies[0].TakeDamage(damage);
                _health.TakeHeal(damage);
            }

            yield return wait;
        }

        _circleShower.CloseCircle();
    }
}

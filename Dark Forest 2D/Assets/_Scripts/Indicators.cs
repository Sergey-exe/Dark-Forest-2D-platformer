using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Indicators : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _protection;
    [SerializeField] private float _percentProtection = 5;
    [SerializeField] private float _energy;
    [SerializeField] private float _maxEnergy;
    [SerializeField] private float _level;

    public float Health => _health;

    public float Level => _level;

    public event UnityAction IsDead;
    
    private void Start()
    {
        _health = _maxHealth;
        _energy = _maxEnergy;
    }

    public void TakeDamage(float damage)
    {
        int percent = 100;

        float damage1 = damage - (_protection / percent * _percentProtection);

        _health -= damage1;


        if (_health <= 0)
            IsDead?.Invoke();
    }

    public void TakeHeal(float heal)
    {
        _health += heal;
        
        if(_health > _maxHealth)
            _health = _maxHealth;
    }
}

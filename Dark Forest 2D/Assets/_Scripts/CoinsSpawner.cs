using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _coin;
    [SerializeField] private int _countCoins;
    [SerializeField] private float _offset;

    private Vector2 _position;

    private void OnEnable()
    {
        _player.CoinSelection += DestroyCoin;
    }

    private void OnDisable()
    {
        _player.CoinSelection -= DestroyCoin;
    }

    private void Start()
    {
        _position = transform.position;
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < _countCoins; i++)
        {
            Instantiate(_coin, _position, Quaternion.identity);
            _position.x += _offset;
        } 
    }

    private void DestroyCoin(Coin coin)
    {
        Destroy(coin.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private int _countCoins;
    [SerializeField] private float _offset;

    private Vector2 _position;

    private void Start()
    {
        _position = transform.position;
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < _countCoins; i++)
        {
            GameObject coin = Instantiate(_coin, _position, Quaternion.identity);

            coin.GetComponent<Coin>().OnPickUp += DestroyCoin;

            _position.x += _offset;
        } 
    }

    private void DestroyCoin(Coin coin)
    {
        coin.OnPickUp -= DestroyCoin;

        Destroy(coin.gameObject);
    }
}

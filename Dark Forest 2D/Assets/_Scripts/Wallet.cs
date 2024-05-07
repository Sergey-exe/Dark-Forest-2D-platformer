using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _countMoneys = 0;

    private void OnEnable()
    {
        _player.CoinSelection += AddMoney;
    }

    private void OnDisable()
    {
        _player.CoinSelection -= AddMoney;
    }

    private void AddMoney(Coin coin)
    {
        _countMoneys += coin.Denomination;
    }
}

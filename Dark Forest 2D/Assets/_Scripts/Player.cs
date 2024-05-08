using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Wallet _wallet; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Coin>())
        {
            collision.GetComponent<Coin>().PickUp();
            _wallet.AddCoins(collision.GetComponent<Coin>().Denomination);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeal : MonoBehaviour
{
    [SerializeField] private Indicators _indicators;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Heart>())
        {
            Bonus heart = collision.GetComponent<Heart>();
            heart.PickUp();
            _indicators.TakeHeal(heart.Denomination);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour 
{
    [SerializeField] private int _denomination;

    public int Denomination => _denomination; 

    public event UnityAction<Coin> OnPickUp;

    public void PickUp()
    {
        OnPickUp?.Invoke(GetComponent<Coin>());
    }
}
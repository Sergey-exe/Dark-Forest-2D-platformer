using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class Bonus : MonoBehaviour 
{
    [SerializeField] private int _denomination;

    public int Denomination => _denomination; 

    public event UnityAction<Bonus> OnPickUp;

    public void PickUp()
    {
        OnPickUp?.Invoke(GetComponent<Bonus>());
    }
}

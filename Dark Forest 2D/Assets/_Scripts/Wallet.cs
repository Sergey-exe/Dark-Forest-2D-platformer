using UnityEngine;

public class Wallet : MonoBehaviour 
{
    [SerializeField] private int _countCoins = 0;

    public void AddCoins(int countCoins)
    {
        _countCoins += countCoins;
    }
}

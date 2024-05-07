using UnityEngine;

public static class Wallet
{
    private static int _countCoins = 0;

    public static void AddCoins(int countCoins)
    {
        _countCoins += countCoins;
    }
}

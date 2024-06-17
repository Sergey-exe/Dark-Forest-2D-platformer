using UnityEngine;

public class PlayerFinance : MonoBehaviour
{
    [SerializeField] private Wallet _wallet; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Coin>())
        {
            collision.GetComponent<Bonus>().PickUp();
            _wallet.AddCoins(collision.GetComponent<Bonus>().Denomination);
        }
    }
}

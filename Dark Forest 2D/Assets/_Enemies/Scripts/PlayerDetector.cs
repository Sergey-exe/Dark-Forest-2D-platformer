using UnityEngine;
using UnityEngine.Events;

public class PlayerDetector : MonoBehaviour
{
    public event UnityAction HasPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerFinance>())
            HasPlayer?.Invoke();
    }
}

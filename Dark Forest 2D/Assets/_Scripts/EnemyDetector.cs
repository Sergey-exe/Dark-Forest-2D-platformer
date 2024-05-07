using UnityEngine;
using UnityEngine.Events;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private string _enemyTag;

    public event UnityAction HasEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            HasEnemy?.Invoke();
        }
    }
}

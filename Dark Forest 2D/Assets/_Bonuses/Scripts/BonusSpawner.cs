using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private Bonus _bonus;
    [SerializeField] private int _countBonus;
    [SerializeField] private float _offset;

    private Vector2 _position;

    private void Start()
    {
        _position = transform.position;
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < _countBonus; i++)
        {
            Bonus coin = Instantiate(_bonus, _position, Quaternion.identity);
            coin.OnPickUp += DestroyBonus;
            _position.x += _offset;
        } 
    }

    private void DestroyBonus(Bonus bonus)
    {
        bonus.OnPickUp -= DestroyBonus;
        Destroy(bonus.gameObject);
    }
}

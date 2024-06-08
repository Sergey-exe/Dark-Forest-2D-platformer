using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyMover : MonoBehaviour
{
    private const string SpiderDeath = nameof(SpiderDeath);

    private Quaternion TurnLeft = Quaternion.Euler(0f, 180f, 0f);
    private Quaternion TurnRight = Quaternion.identity;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private ObstructionDetector _obstructionDetector;
    [SerializeField] private ObstructionDetector _groundDetector;
    [SerializeField] private PlayerDetector _playerDetector;
    [SerializeField] private Animator _animator;
    [SerializeField] private Indicators _indicators;

    private int _axis = 1;
    private Vector2 _movementDirection;

    private void OnEnable()
    {
        _playerDetector.HasPlayer += ChangeDirection;
        _indicators.IsDeaded += Death;
    }

    private void OnDisable()
    {
        _playerDetector.HasPlayer -= ChangeDirection;
        _indicators.IsDeaded -= Death;
    }

    private void Update()
    {
        Move();
        Rotate(_axis);
    }

    private void Rotate(int velocityX)
    {
        switch (velocityX)
        {
            case < 0:
                transform.localRotation = TurnRight;
                break;

            case > 0:
                transform.localRotation = TurnLeft;
                break;
        }
    }

    private void Move()
    {
        _movementDirection.x = _moveSpeed * _axis;
        transform.Translate(_movementDirection, Space.World);

        if (_obstructionDetector.HasObstruction)
            ChangeDirection();
    }

    private void ChangeDirection()
    {
        int directionBack = -1;

        _axis *= directionBack;
    }

    private void Death()
    {
        Destroy(GetComponent<EnemyMover>());
    }
}

using UnityEngine;

public class Spider : MonoBehaviour
{
    private Quaternion TurnLeft = Quaternion.Euler(0f, 180f, 0f);
    private Quaternion TurnRight = Quaternion.identity;

    [SerializeField] private ObstructionDetector _obstructionIdentifier;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Vector2 _movementDirection;
    private int _axis = 1;

    private void OnEnable()
    {
        _obstructionIdentifier.HasObstruction += ChangeDirection;
    }

    private void OnDisable()
    {
        _obstructionIdentifier.HasObstruction -= ChangeDirection;
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
    }

    private void ChangeDirection()
    {
        int directionBack = -1;

        _axis *= directionBack;
    }
}

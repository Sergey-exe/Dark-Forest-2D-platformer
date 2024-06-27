using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const string PlayerDeath = nameof(PlayerDeath);
    private readonly int IsRun = Animator.StringToHash("Run");

    private Quaternion TurnLeft = Quaternion.Euler(0f, 180f, 0f);
    private Quaternion TurnRight = Quaternion.identity;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private ObstructionDetector _groundDetector;
    [SerializeField] private Health _indicators;
    [SerializeField] private Animator _animator;
    [SerializeField] private InputReader _inputReader;

    private float _axis;
    private bool _isRun;
    private Vector2 _movementDirection;
    private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        _indicators.IsDeaded += Death;
    }

    private void OnDisable()
    {
        _indicators.IsDeaded -= Death;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _axis = _inputReader.InputMoveAxis();

        Jump();
        Move();
        Rotate();
    }

    private void Move()
    {
        _movementDirection.x = _moveSpeed * _axis;
        transform.Translate(_movementDirection, Space.World);
        _isRun = _axis != 0;
        _animator.SetBool(IsRun, _isRun);
    }

    private void Rotate()
    {
        switch (_axis)
        {
            case > 0:
                transform.localRotation = TurnRight;
                break;
            case < 0:
                transform.localRotation = TurnLeft;
                break;
        }
    }

    private void Jump()
    {
        if (_inputReader.DownButtonPlayerJump() && _groundDetector.HasObstruction == false)
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void Death()
    {
        _animator.Play(PlayerDeath);
        Destroy(GetComponent<PlayerMover>());
    }
}

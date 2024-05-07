using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private Quaternion TurnLeft = Quaternion.Euler(0f, 180f, 0f);
    private Quaternion TurnRight = Quaternion.identity;
    private readonly int IsRun = Animator.StringToHash("Run");

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _rayDistance;
    [SerializeField] private Transform _rayStarter;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Animator _animator;

    private Vector2 _movementDirection;
    private Rigidbody2D _rigidbody;
    private bool _isGround;
    private bool _isRun;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var axis = Input.GetAxis(Horizontal);

        Jump();
        Move(axis);
        Rotate(axis);
    }

    private void FixedUpdate()
    {
        Vector2 direction = Vector2.down;
        RaycastHit2D hit = Physics2D.Raycast(_rayStarter.position, direction, _rayDistance, _layerMask);

        _isGround = hit.collider != null;
    }

    private void LateUpdate()
    {
        Debug.DrawRay(_rayStarter.position, Vector2.down * _rayDistance, Color.yellow);
    }

    private void Move(float axis)
    {
        _movementDirection.x = _moveSpeed * axis;
        transform.Translate(_movementDirection, Space.World);

        _isRun = axis != 0;
        _animator.SetBool(IsRun, _isRun);
    }

    private void Rotate(float velocityX)
    {
        switch (velocityX)
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
        if(Input.GetKeyDown(KeyCode.Space) && _isGround)
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}

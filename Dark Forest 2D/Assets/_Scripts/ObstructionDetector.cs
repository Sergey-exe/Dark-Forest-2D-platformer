using UnityEngine;
using UnityEngine.Events;

public class ObstructionDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _layerObstruction;
    [SerializeField] private float _rayDistance;
    [SerializeField] private Color32 _rayColor;

    private Vector2 _directionForwardHit = Vector2.down;
    private Vector2 _directionDownHit;
    
    public bool HasObstruction { get; private set; }

    private void Start()
    {
        _directionDownHit = Vector2.down;
    }

    private void Update()
    {
        RotationRaycast();
    }

    private void FixedUpdate()
    {
        RaycastHit2D forwardHit = Physics2D.Raycast(transform.position, _directionForwardHit, _rayDistance, _layerObstruction);
        RaycastHit2D downHit = Physics2D.Raycast(transform.position, _directionDownHit, _rayDistance, _layerObstruction);
        HasObstruction = forwardHit.collider != null || downHit.collider == null;
    }

    private void LateUpdate()
    {
        Debug.DrawRay(transform.position, _directionForwardHit * _rayDistance, _rayColor);
        Debug.DrawRay(transform.position, _directionDownHit * _rayDistance, _rayColor);
    }

    private void RotationRaycast()
    {
        if (transform.rotation.y == 0)
            _directionForwardHit = Vector2.left;
        else
            _directionForwardHit = Vector2.right;
    }
}

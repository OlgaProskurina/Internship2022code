using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private MovementSO _movement;

    private Vector2 _movementDirection;

    public void OnMove(InputAction.CallbackContext context)
    {
        _movementDirection = context.ReadValue<Vector2>();
    }


    private void Move()
    {

        _rb.MovePosition(_rb.position + _movementDirection * _movement.Speed * Time.fixedDeltaTime);

        if (_movementDirection != Vector2.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, _movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _movement.RotationSpeed * Time.fixedDeltaTime);
        }
    }


    private void FixedUpdate()
    {
        Move();
    }

}

using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 8f;
    [SerializeField] private InputActionReference _move;

    [SerializeField] private float _jumpSpeed = 12f;
    [SerializeField] private InputActionReference _jump;

    private Rigidbody2D _body;
    private float _horizontal;
    private bool _jumpRequested;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _move.action.Enable();
        _jump.action.Enable();
    }

    private void OnDisable()
    {
        _move.action.Disable();
        _jump.action.Disable();
    }

    private void Update()
    {
        if (_jump.action.WasPressedThisFrame())
        {
            _jumpRequested = true;
        }

        _horizontal = _move.action.ReadValue<Vector2>().x;
    }

    private void FixedUpdate()
    {
        Vector2 velocity = _body.linearVelocity;
        velocity.x = _horizontal * _moveSpeed;

        if (_jumpRequested)
        {
            velocity.y = _jumpSpeed;
            _jumpRequested = false;
        }

        _body.linearVelocity = velocity;
    }
}

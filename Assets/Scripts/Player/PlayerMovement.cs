using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 8f;
    [SerializeField] private InputActionReference _move;

    private Rigidbody2D _body;
    private float _horizontal;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _move.action.Enable();
    }

    private void OnDisable()
    {
        _move.action.Disable();
    }

    private void Update()
    {
        _horizontal = _move.action.ReadValue<Vector2>().x;
    }

    private void FixedUpdate()
    {
        _body.linearVelocity = new Vector2(_horizontal * _moveSpeed, _body.linearVelocity.y);
    }
}

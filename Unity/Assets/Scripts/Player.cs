using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;
    private SpriteRenderer _spriteRenderer;
    private Camera _camera;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    private void Update()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _direction.Normalize();

        transform.position = _rigidbody2D.position.ClampPositionToScreen(_camera.GetViewportBounds(),_spriteRenderer.GetBoundsSize());

    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direction * _movementSpeed * Time.fixedDeltaTime);
        //RestrictMovement();
    }
    
    private void RestrictMovement()
    {
        var upperRightCorner = _camera.ViewportToWorldPoint(new Vector3(1, 1, 0));
        var lowerLeftCorner = _camera.ViewportToWorldPoint(new Vector3(0, 0, 0));

        var bounds = _spriteRenderer.bounds;
        var playerWidth = bounds.size.x / 2;
        var playerHeight = bounds.size.y / 2;

        var position = transform.position;
        var xVal = Mathf.Clamp(position.x, lowerLeftCorner.x + playerWidth, upperRightCorner.x - playerWidth);
        var yVal = Mathf.Clamp(position.y, lowerLeftCorner.y + playerHeight, upperRightCorner.y - playerHeight);

        position = new Vector3(xVal, yVal, 0);
        transform.position = position;
    }
}

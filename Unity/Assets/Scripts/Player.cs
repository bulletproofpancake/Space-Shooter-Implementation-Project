using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;
    private SpriteRenderer _spriteRenderer;
    private Camera _camera;
    private CameraBounds _cameraBounds;
    private Vector2 _spriteBounds;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
        _cameraBounds = new CameraBounds(_camera);

        _spriteBounds = _spriteRenderer.bounds.size * 0.5f;
    }

    private void Update()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _direction.Normalize();

        //RestrictMovement();

        transform.position = _rigidbody2D.position.ClampPositionToScreen(_cameraBounds);

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

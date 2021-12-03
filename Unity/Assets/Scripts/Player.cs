using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _movementSpeed;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;
    
    private Camera _camera;
    private SpriteRenderer _spriteRenderer;

    [Header("Health")] 
    [SerializeField] private int _life;
    
    [Header("Combat")] 
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firingPoints;
    [SerializeField] private float _fireRate;
    
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
        
        if(Input.GetKey(KeyCode.Space)) Shoot();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direction * _movementSpeed * Time.fixedDeltaTime);
    }

    private void Shoot()
    {
        foreach (Transform firingPoint in _firingPoints)
        {
            var bullet = Instantiate(_bulletPrefab);
            bullet.transform.position = firingPoint.position;
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 25f);
        }
    }
}

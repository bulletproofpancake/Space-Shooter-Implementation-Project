using Godot;
using System;

public class Player : Area2D
{
    [Export()] private float _movementSpeed = 100f;
    private Vector2 _direction;
    
    private Vector2 _screenSize;
    private Sprite _sprite;

    public override void _Ready()
    {
        _screenSize = GetViewportRect().Size;
        _sprite = GetNode<Sprite>("Sprite");
    }

    public override void _Process(float delta)
    {
        _direction = Vector2.Zero;
        if (Input.IsActionPressed("move_up"))
            _direction.y = -1;
        else if (Input.IsActionPressed("move_down"))
            _direction.y = 1;
        if (Input.IsActionPressed("move_left"))
            _direction.x = -1;
        else if (Input.IsActionPressed("move_right"))
            _direction.x = 1;
    }

    public override void _PhysicsProcess(float delta)
    {
        Position += _direction.Normalized() * _movementSpeed * delta;
        Position = ClampPositionToScreen(Position, _sprite);
    }

    /// <summary>
    /// Clamps the position within the viewport 
    /// </summary>
    /// <param name="position">Position of the object that needs to be clamped</param>
    /// <returns>Clamped object position</returns>
    private Vector2 ClampPositionToScreen(Vector2 position)
    {
        return new Vector2(
            Mathf.Clamp(position.x, 0, _screenSize.x),
            Mathf.Clamp(position.y, 0, _screenSize.y)
        );
    }
    
    /// <summary>
    /// Clamps the position within the viewport with an offset by the sprite of the object
    /// </summary>
    /// <param name="position">Position of the object that needs to be clamped</param>
    /// <param name="sprite">Sprite of the object that needs to be clamped</param>
    /// <returns>Clamped object position</returns>
    private Vector2 ClampPositionToScreen(Vector2 position, Sprite sprite)
    {
        var size = sprite.Texture.GetSize() * sprite.Scale / 2; 
        
        return new Vector2(
            Mathf.Clamp(position.x, 0 + size.x, _screenSize.x - size.x),
            Mathf.Clamp(position.y, 0 + size.y, _screenSize.y - size.y)
        );
    }
}

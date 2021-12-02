using Godot;

public static class Vector2Extensions
{
    /// <summary>
    /// Clamps the position within the viewport 
    /// </summary>
    /// <param name="position">Position of the object that needs to be clamped</param>
    /// <param name="screenSize">The size of the viewport</param>
    /// <returns>Clamped object position</returns>
    public static Vector2 ClampPositionToScreen(this Vector2 position, Vector2 screenSize)
    {
        return new Vector2(
            Mathf.Clamp(position.x, 0, screenSize.x),
            Mathf.Clamp(position.y, 0, screenSize.y)
        );
    }

    /// <summary>
    /// Clamps the position within the viewport with an offset by the sprite of the object
    /// </summary>
    /// <param name="position">Position of the object that needs to be clamped</param>
    /// <param name="screenSize">The size of the viewport</param>
    /// <param name="sprite">Sprite of the object that needs to be clamped</param>
    /// <returns>Clamped object position</returns>
    public static Vector2 ClampPositionToScreen(this Vector2 position, Vector2 screenSize, Sprite sprite)
    {
        var size = sprite.Texture.GetSize() * sprite.Scale / 2;

        return new Vector2(
            Mathf.Clamp(position.x, 0 + size.x, screenSize.x - size.x),
            Mathf.Clamp(position.y, 0 + size.y, screenSize.y - size.y)
        );
    }
}

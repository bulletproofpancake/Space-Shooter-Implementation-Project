using UnityEngine;

public static class Vector2Extensions
{
    /// <summary>
    /// Clamps the position within the viewport 
    /// </summary>
    /// <param name="position">Position of the object that needs to be clamped</param>
    /// <param name="screenSize">The size of the viewport</param>
    /// <returns>Clamped object position</returns>
    public static Vector2 ClampPositionToScreen(this Vector2 position)
    {
        Vector2 upperRightBounds = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        Vector2 lowerLeftBounds = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        
        return new Vector2(
            Mathf.Clamp(position.x, lowerLeftBounds.x, upperRightBounds.x),
            Mathf.Clamp(position.y, lowerLeftBounds.y, upperRightBounds.y)
        );
    }

    /// <summary>
    /// Clamps the position within the viewport with an offset by the sprite of the object
    /// </summary>
    /// <param name="position">Position of the object that needs to be clamped</param>
    /// <param name="spriteRenderer">Sprite of the object that needs to be clamped</param>
    /// <returns>Clamped object position. <b>RETURN TO <c> transform.position</c> FOR BEST RESULTS</b></returns>
    public static Vector2 ClampPositionToScreen(this Vector2 position, CameraBounds cameraBounds, Vector2 size)
    {
        return new Vector2(
            Mathf.Clamp(position.x, cameraBounds.lowerLeft.x + size.x, cameraBounds.upperRight.x - size.x),
            Mathf.Clamp(position.y, cameraBounds.lowerLeft.y + size.y, cameraBounds.upperRight.y - size.y)
        );
    }

    public struct CameraBounds
    {
        public Vector2 upperRight;
        public Vector2 lowerLeft;

        public CameraBounds(Vector2 upperRight, Vector2 lowerLeft)
        {
            this.upperRight = upperRight;
            this.lowerLeft = lowerLeft;
        }

        public CameraBounds(Camera _camera)
        {
            this.upperRight = _camera.ViewportToWorldPoint(new Vector3(1, 1, 0));
            this.lowerLeft =  _camera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        }
    }
}

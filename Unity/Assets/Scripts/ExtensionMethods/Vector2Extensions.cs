using UnityEngine;

public static class Vector2Extensions
{
    /// <summary>
    /// Clamps the position within the viewport 
    /// </summary>
    /// <param name="position">Position of the object that needs to be clamped</param>
    /// <param name="cameraBounds">The bounds of the camera</param>
    /// <returns>Clamped object position. <b>RETURN TO <c> transform.position</c> FOR BEST RESULTS</b></returns>
    public static Vector2 ClampPositionToScreen(this Vector2 position, CameraBounds cameraBounds)
    {
        return new Vector2(
            Mathf.Clamp(position.x, cameraBounds.lowerLeft.x, cameraBounds.upperRight.x),
            Mathf.Clamp(position.y, cameraBounds.lowerLeft.y, cameraBounds.upperRight.y)
        );
    }

   /// <summary>
   /// Clamps the position within the viewport with an offset by the sprite of the object
   /// </summary>
   /// <param name="position">Position of the object that needs to be clamped</param>
   /// <param name="cameraBounds">The bounds of the camera</param>
   /// <param name="spriteBounds">The bounds of the sprite</param>
   /// <returns>Clamped object position according to sprite offset. <b>RETURN TO <c> transform.position</c> FOR BEST RESULTS</b></returns>
    public static Vector2 ClampPositionToScreen(this Vector2 position, CameraBounds cameraBounds, Vector2 spriteBounds)
    {
        return new Vector2(
            Mathf.Clamp(position.x, cameraBounds.lowerLeft.x + spriteBounds.x, cameraBounds.upperRight.x - spriteBounds.x),
            Mathf.Clamp(position.y, cameraBounds.lowerLeft.y + spriteBounds.y, cameraBounds.upperRight.y - spriteBounds.y)
        );
    }
}

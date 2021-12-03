using UnityEngine;

public static class SpriteRendererExtensions
{
    public static Vector2 GetBoundsSize(this SpriteRenderer spriteRenderer)
    {
        return spriteRenderer.bounds.size * 0.5f;
    }
    
    public static Vector2 GetBoundsSize(this SpriteRenderer spriteRenderer, bool isNotHalf)
    {
        return isNotHalf ? spriteRenderer.bounds.size : spriteRenderer.bounds.size * 0.5f;
    }
}

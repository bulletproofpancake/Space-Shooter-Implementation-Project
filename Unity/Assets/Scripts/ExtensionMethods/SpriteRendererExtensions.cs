using UnityEngine;

public static class SpriteRendererExtensions
{
    /// <summary>
    /// Returns <b>half</b> of the value of <c>spriteRenderer.bounds.size</c>
    /// </summary>
    public static Vector2 GetBoundsSize(this SpriteRenderer spriteRenderer)
    {
        return spriteRenderer.bounds.size * 0.5f;
    }
    
    /// <summary>
    /// Returns either the <b>original</b> or <b>half</b> of the value of <c>spriteRenderer.bounds.size</c>
    /// </summary>
    /// <param name="isNotHalf">Indicates whether the full bounds size should be returned or just half</param>
    public static Vector2 GetBoundsSize(this SpriteRenderer spriteRenderer, bool isNotHalf)
    {
        return isNotHalf ? spriteRenderer.bounds.size : spriteRenderer.bounds.size * 0.5f;
    }
}

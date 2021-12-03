using UnityEngine;

public struct CameraBounds
{
    public Vector2 upperRight;
    public Vector2 lowerLeft;

    public CameraBounds(Camera _camera)
    {
        this.upperRight = _camera.ViewportToWorldPoint(new Vector3(1, 1, 0));
        this.lowerLeft = _camera.ViewportToWorldPoint(new Vector3(0, 0, 0));
    }
}
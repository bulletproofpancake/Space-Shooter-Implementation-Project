using UnityEngine;

public static class CameraExtensions
{
    public static CameraBounds GetViewportBounds(this Camera camera)
    {
        return new CameraBounds(camera);
    }
}

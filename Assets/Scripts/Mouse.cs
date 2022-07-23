using UnityEngine;


// Set of utilities around mouse data
public static class Mouse
{
    private static Camera _camera;
    private static Camera MainCamera
    {
        get
        {
            if (_camera == null)
                _camera = Camera.main;

            return _camera;

        }
    }

    public static Vector2 WorldPosition { 
        get
        {
            return MainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
    }

}
using System.Numerics;

public class Transformable
{
    private Vector3 _position;
    private Quaternion _rotation;
    private Vector3 _scale;

    public Transformable(Vector3 position, Quaternion rotation, Vector3 scale)
    {
        _position = position;
        _rotation = rotation;
        _scale = scale;
    }

    public void UpdateTransform(Vector3 position, Quaternion rotation, Vector3 scale)
    {
        _position = position;
        _rotation = rotation;
        _scale = scale;
    }
}
using System.Collections;
using TransformParametersConverter;
using UnityEngine;

public class RotationView : MonoBehaviour
{
    [SerializeField] private float _rotationAngle;

    private Transform _transform;
    private Transformable _sphere;

    private void Awake()
    {
        _transform = transform;
        _sphere = new Transformable(VectorConverter.ToNumerics(_transform.position),
            QuaternionConverter.ToNumerics(_transform.rotation), VectorConverter.ToNumerics(_transform.localScale));
    }

    private void Start()
    {
        StartCoroutine(RotateAround(Vector3.up));
    }

    private IEnumerator RotateAround(Vector3 rotationAxis)
    {
        while (Application.isPlaying)
        {
            _transform.Rotate(rotationAxis, _rotationAngle * Time.deltaTime);
            _sphere.UpdateTransform(VectorConverter.ToNumerics(_transform.position),
            QuaternionConverter.ToNumerics(_transform.rotation), VectorConverter.ToNumerics(_transform.localScale));

            yield return null;
        }
    }
}

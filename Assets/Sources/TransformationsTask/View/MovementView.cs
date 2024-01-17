using System.Collections;
using TransformParametersConverter;
using UnityEngine;

public class MovementView : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Transform _targetPosition;

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
        StartCoroutine(MoveLoopTo(_targetPosition.position));
    }

    private IEnumerator MoveLoopTo(Vector3 targetPosition)
    {
        Vector3 startPosition = _transform.position;

        while (Application.isPlaying)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, targetPosition, _speed * Time.deltaTime);
            _sphere.UpdateTransform(VectorConverter.ToNumerics(_transform.position),
            QuaternionConverter.ToNumerics(_transform.rotation), VectorConverter.ToNumerics(_transform.localScale));

            if (_transform.position == targetPosition)
            {
                var tempPosition = targetPosition;
                targetPosition = startPosition;
                startPosition = tempPosition;
            }

            yield return null;
        }
    }
}

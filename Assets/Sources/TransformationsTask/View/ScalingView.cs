using System.Collections;
using TransformParametersConverter;
using UnityEngine;

public class ScalingView : MonoBehaviour
{
    [SerializeField] private float _scalingSpeed;

    [SerializeField] private Vector3 _targetScale;

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
        StartCoroutine(ScaleLoopTo(_targetScale));
    }

    private IEnumerator ScaleLoopTo(Vector3 targetScale)
    {
        Vector3 startScale = _transform.localScale;

        while (Application.isPlaying)
        {
            _transform.localScale = Vector3.MoveTowards(_transform.localScale, targetScale, _scalingSpeed * Time.deltaTime);
            _sphere.UpdateTransform(VectorConverter.ToNumerics(_transform.position),
            QuaternionConverter.ToNumerics(_transform.rotation), VectorConverter.ToNumerics(_transform.localScale));

            if (_transform.localScale == targetScale)
            {
                var tempScale = targetScale;
                targetScale = startScale;
                startScale = tempScale;
            }

            yield return null;
        }
    }
}
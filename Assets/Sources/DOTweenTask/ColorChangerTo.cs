using DG.Tweening;
using UnityEngine;

public class ColorChangerTo : MonoBehaviour
{
    [SerializeField] private Color _targetColor;
    [SerializeField] private Material _material;
    [SerializeField] private LoopType _loopType;

    [SerializeField] private float _duration;
    [SerializeField] private int _repeats = -1;

    private Color _defaultMaterialColor;

    private void Start()
    {
        _defaultMaterialColor = _material.color;

        _material.DOColor(_targetColor, _duration).SetLoops(_repeats, _loopType);
    }

    private void OnDisable()
    {
        _material.color = _defaultMaterialColor;
    }
}

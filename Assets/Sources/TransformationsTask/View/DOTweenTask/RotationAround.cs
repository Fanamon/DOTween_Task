using DG.Tweening;
using UnityEngine;

public class RotationAround : MonoBehaviour
{
    [SerializeField] private Vector3 _rotationPoint;
    [SerializeField] private RotateMode _rotateMode;
    [SerializeField] private LoopType _loopType;

    [SerializeField] private float _duration;
    [SerializeField] private int _repeats = -1;

    private void Start()
    {
        transform.DORotate(_rotationPoint, _duration, _rotateMode).SetLoops(_repeats, _loopType).
            SetEase(Ease.Linear);
    }
}

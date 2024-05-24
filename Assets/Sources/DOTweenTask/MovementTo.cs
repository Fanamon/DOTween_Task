using DG.Tweening;
using UnityEngine;

public class MovementTo : MonoBehaviour
{
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private LoopType _loopType;

    [SerializeField] private float _duration;
    [SerializeField] private int _repeats = -1;

    private void Start()
    {
        transform.DOMove(_targetPosition.position, _duration).SetLoops(_repeats, _loopType);
    }
}
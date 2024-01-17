using DG.Tweening;
using UnityEngine;

public class ScalingTo : MonoBehaviour
{
    [SerializeField] private Vector3 _scalingSize;
    [SerializeField] private LoopType _loopType;

    [SerializeField] private float _duration;
    [SerializeField] private int _repeats = -1;

    private void Start()
    {
        transform.DOScale(_scalingSize, _duration).SetLoops(_repeats, _loopType).
            SetEase(Ease.Linear);
    }
}

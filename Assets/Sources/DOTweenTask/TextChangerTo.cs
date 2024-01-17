using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TextChangerTo : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private LoopType _loopType;

    [SerializeField] private float _duration;
    [SerializeField] private int _repeats = -1;

    [SerializeField] private string _targetText;

    private string _defaultText;

    private void Start()
    {
        _defaultText = _text.text;

        DOTween.Sequence().Append(_text.DOText(_targetText, _duration)).
            Append(_text.DOText(_defaultText, _duration).SetRelative()).
            Append(_text.DOText(_targetText, _duration, true, ScrambleMode.All)).
            SetLoops(_repeats, _loopType);
    }

    private void OnDisable()
    {
        _text.text = _defaultText;
    }
}

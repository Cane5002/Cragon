using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PullPanel : MonoBehaviour
{
    private RectTransform _transform;
    [SerializeField]
    private Vector2 _outPosition;
    [SerializeField]
    private Vector2 _inPosition;
    private Vector2 _originPosition;
    private Vector2 _targetPosition;
    public bool PanelIn;

    [SerializeField]
    private float _moveDuration = 1;
    private float _timeElapsed;

    float lerpedValue;

    void Awake() {
        _transform = gameObject.GetComponent<RectTransform>();
    }
    void Start() {
        _originPosition = _transform.anchoredPosition;
        _targetPosition = (PanelIn ? _inPosition : _outPosition);
        PanelIn = true;
    }

    void Update() {
        if (_timeElapsed < _moveDuration) {
            float t = Mathf.SmoothStep(0, 1, _timeElapsed / _moveDuration);
            _transform.anchoredPosition = Vector2.Lerp(_originPosition, _targetPosition, t / _moveDuration);
            _timeElapsed += Time.deltaTime;
        }
    }

    public void PullIn() {
        _targetPosition = _inPosition;
        _originPosition = _transform.anchoredPosition;
        _timeElapsed = Mathf.Max(_moveDuration - _timeElapsed, 0);
        PanelIn = true;
    }
    public void PullOut() {
        _targetPosition = _outPosition;
        _originPosition = _transform.anchoredPosition;
        _timeElapsed = Mathf.Max(_moveDuration - _timeElapsed, 0);
        PanelIn = false;
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExpandablePanel : MonoBehaviour, IPointerClickHandler
{
    private RectTransform _transform;
    [SerializeField]
    private RectTransform _headerPanel;
    [SerializeField]
    private RectTransform _hiddenPanel;
    private Vector2 _originSize;
    private Vector2 _targetSize;
    [SerializeField]
    private bool _isExpanded = false;

    [SerializeField]
    private float _moveDuration;
    private float _timeElapsed;

    void Awake() {
        _transform = gameObject.GetComponent<RectTransform>();
    }

    void Start() {
        _originSize = _transform.sizeDelta;
        _targetSize = _headerPanel.sizeDelta;
    }

    void Update() {
        if (_timeElapsed < _moveDuration) {
            float t = Mathf.SmoothStep(0, 1, _timeElapsed / _moveDuration);
            _transform.sizeDelta = Vector2.Lerp(_originSize, _targetSize, t);
            _timeElapsed += Time.deltaTime;
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (_isExpanded) UnExpand();
        else Expand();
    }

    void Expand() {
        _originSize = _transform.sizeDelta;
        _targetSize = _originSize + new Vector2(0, _hiddenPanel.sizeDelta.y);
        _timeElapsed = Mathf.Max(_moveDuration - _timeElapsed, 0);
        _isExpanded = true;

    }

    void UnExpand() {
        _originSize = _transform.sizeDelta;
        _targetSize = _headerPanel.sizeDelta;
        _timeElapsed = Mathf.Max(_moveDuration - _timeElapsed, 0);
        _isExpanded = false;
    }
}

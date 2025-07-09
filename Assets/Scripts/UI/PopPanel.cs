using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;


public class PopPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
        _targetPosition = _inPosition;
        PanelIn = true;
    }

    void Update() {
        if (_timeElapsed < _moveDuration) {
            float t = Mathf.SmoothStep(0, 1, _timeElapsed / _moveDuration);
            _transform.anchoredPosition = Vector2.Lerp(_originPosition, _targetPosition, t / _moveDuration);
            _timeElapsed += Time.deltaTime;
        }
    }
    public void OnPointerEnter(PointerEventData eventData) {
        PopOut();
    }
    public void OnPointerExit(PointerEventData eventData) {
        PopIn();
    }

    public void PopIn() {
        _targetPosition = _inPosition;
        _originPosition = _transform.anchoredPosition;
        _timeElapsed = Mathf.Max(_moveDuration - _timeElapsed, 0);
        PanelIn = true;
    }
    public void PopOut() {
        _targetPosition = _outPosition;
        _originPosition = _transform.anchoredPosition;
        _timeElapsed = Mathf.Max(_moveDuration - _timeElapsed, 0);
        PanelIn = false;
    }
}

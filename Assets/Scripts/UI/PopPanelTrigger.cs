using UnityEngine;
using UnityEngine.EventSystems;

public class PopPanelTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{
    [SerializeField]
    private PopPanel _panel;

    public void OnPointerEnter(PointerEventData eventData) {
        _panel.PopOut();
        Debug.Log("Pop out");
    }
    public void OnPointerExit(PointerEventData eventData) {
        _panel.PopIn();
        Debug.Log("Pop in");
    }
}

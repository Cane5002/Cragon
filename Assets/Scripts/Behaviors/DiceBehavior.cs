using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DiceBehavior : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _diceBody;
    [SerializeField] private Image _faceImage;
    [SerializeField] private GameObject _highlightBorder;
    [SerializeField] private GameObject _selectBorder;
    [SerializeField] private GameObject _lockBorder;


    private Dice _dice;
    public int Number { get { return _dice.CurrentFace.Number; } }
    public Element Type { get { return _dice.CurrentFace.Type; } }

    public void Update() {
        _selectBorder.SetActive(_dice.Selected);
        _lockBorder.SetActive(_dice.Locked);
    }

    public virtual void Setup(Dice dice) {
        _dice = dice;
        _diceBody.color = _dice.DiceColor;
        _faceImage.sprite = _dice.Roll().Image;
    }

    public virtual void Roll() {
        _diceBody.sprite = _dice.Roll().Image;
    }
    void Destruct() {
        Destroy(this.gameObject);
    }
    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Left) _dice.ToggleSelect();
        else if (eventData.button == PointerEventData.InputButton.Right) _dice.ToggleLocked();
    }
    public void OnPointerEnter(PointerEventData eventData) {
        _highlightBorder.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData) {
        _highlightBorder.SetActive(false);
    }




}

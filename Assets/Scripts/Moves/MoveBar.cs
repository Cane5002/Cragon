using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveBar : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Image _costImage;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private Button _useButton;

    [SerializeField] private Action _move;

    [SerializeField] private Color _activeMoveColor;
    [SerializeField] private Color _passiveMoveColor;
    [SerializeField] private Color _counterMoveColor;

    public void Setup(string name, Sprite costSprite, string description, Action move) {
        _nameText.text = name;
        _costImage.sprite = costSprite;
        _descriptionText.text = description;
        _move = move;
        _background.color = _activeMoveColor;
    }
    public void Setup(string name, Sprite costSprite, string description, MoveType type) {
        _nameText.text = name;
        _costImage.sprite = costSprite;
        _descriptionText.text = description;
        _useButton.enabled = false;
        if (type == MoveType.Passive) _background.color = _passiveMoveColor;
        else if (type == MoveType.Counter) _background.color = _counterMoveColor;
    }

    public void SetUseIcon(bool canUse) {
        if (_useButton) _useButton.interactable = canUse;
    }

    public void Use() {
        _move?.Invoke();
    }
}

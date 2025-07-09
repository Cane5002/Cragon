using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiceBehavior : DiceBehavior
{
    [SerializeField] private GameObject _lockBorder;
    [SerializeField] private GameObject _selectBorder;

    private bool _locked = false;
    private bool _selected = false;

    private void ToggleLocked() {
        _locked = !_locked;
        _lockBorder.SetActive(_locked);
    }
    private void ToggleSelect() {
        _selected = !_selected;
        _selectBorder.SetActive(_selected);
    }
}

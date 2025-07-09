using System;
using UnityEngine;

[System.Serializable]
public class Dice
{
    private DiceData _data;
    public DiceFaceData CurrentFace { get; private set; }
    public Color DiceColor { get { return _data.Color;  } }
    public bool Selected { get; private set; }
    public bool Locked { get; private set; }

    public Dice(DiceData diceData) {
        Debug.Log("\tSpawning Dice[" + diceData.Name + "]");
        _data = diceData;
        Roll();
    }

    public DiceFaceData Roll() {
        Debug.Log("\tRolling Dice[" + _data.Name + "]");
        CurrentFace = _data.GetRandomFace();
        return CurrentFace;
    }
    public void ToggleLock() {
        //if (!_manager.CanLock) return _locked;
        Locked = !Locked;
    }
    public bool ToggleSelect() {
        //if (!_manager.CanSelect) return _selected;
        Selected = !Selected;
        //if (_selected) _manager.Select(this);
        //else _manager.UnSelect(this);
    }
}
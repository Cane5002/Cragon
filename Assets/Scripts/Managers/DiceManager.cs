using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceManager : MonoBehaviour
{
    //-----------------------PREFABS-------------------------
    [SerializeField] private GameObject _dicePrefab;
    //----------------------UI OBJECTS-----------------------
    [SerializeField] private GameObject _diceDisplay;
    [SerializeField] private Button _rollBtn;
    //----------------------PROPERTIES-----------------------
    public int rolls { get; private set; } = 0;
    [SerializeField] private int baseRerolls = 3;
    //-----------------------STATES--------------------------
    public bool CanLock { get; private set; } = false;
    public bool CanSelect { get; private set; } = false;
    //-----------------------ACTIONS-------------------------
    public event Action OnRoll;
    public event Action OnSelect;

    #region EQUIPPED DICE - owned dice (between rounds/combat)
    [SerializeField] private List<DiceData> _equipped = new List<DiceData>();
    public void Equip(DiceData dice) { 
        _equipped.Add(dice); 
    }
    public void Equip(List<DiceData> dice) {
        foreach (DiceData d in dice) Equip(d);
    }
    public void UnEquip(DiceData dice) { 
        _equipped.Remove(dice); 
    }
    #endregion

    #region DICE HAND - dice currently being rolled (during a round)
    [SerializeField]private List<Dice> _hand = new List<Dice>();
    public List<Dice> Hand { get { return _hand; } }
    public void AddToHand(DiceData die) {
        Dice newDice = new Dice(die, this);
        GameObject inst = Instantiate(_dicePrefab, _diceDisplay.transform);
        inst.GetComponent<DiceBehavior>().Setup(newDice);
        _hand.Add(newDice);
    }
    public void AddToHand(List<DiceData> dice) {
        foreach (DiceData d in dice) AddToHand(d);
    }
    public void Spend(Dice die) {
        die.Destroy();
        _hand.Remove(die);
        _selected.Remove(die);
    }
    public void Spend(List<Dice> dice) {
        foreach (Dice d in dice) Spend(d);
    }
    #endregion

    #region SELECTED DICE - dice selected to use
    [SerializeField] private List<Dice> _selected = new List<Dice>();
    public List<Dice> Selected { get { return _selected; } }
    public void Select(Dice dice) {
        _selected.Add(dice);
        OnSelect?.Invoke();
    }
    public void UnSelect(Dice dice) {
        _selected.Remove(dice);
        OnSelect?.Invoke();
    }
    #endregion

    #region DICE ACTIONS
    public void LoadDice() => AddToHand(_equipped);
    public void ClearDice() {
        foreach (Dice d in _hand) {
            d.Destroy();
        }
        _hand.Clear();
        _selected.Clear();
    }
    public void ResetDice() {
        ClearDice();
        LoadDice();
        CanLock = false;
        CanSelect = false;
        rolls = 0;
    }

    public void RollDice() {
        CanLock = true;
        CanSelect = true;
        foreach (Dice d in _hand) {
            d.Roll();
        }
        AddRolls(-1);
        OnRoll?.Invoke();
    }
    #endregion

    #region OPERATIONS
    public void AddRolls(int count) {
        rolls += count;
        if (_rollBtn) _rollBtn.interactable = (rolls > 0);
    }
    public void RefreshRolls() {
        rolls = Mathf.Max(0, rolls + baseRerolls);
        if (_rollBtn) _rollBtn.interactable = (rolls > 0);
    }
    #endregion
}

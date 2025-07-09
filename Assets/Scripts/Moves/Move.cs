using Codice.Client.Common.GameUI;
using System;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Move", menuName = "ScriptableObjects/Move", order = 3)]
public abstract class Move : ScriptableObject
{
    public string Name = "";
    public Sprite CostSprite = null;
    public string Description = "";
    abstract public MoveType Type { get; }


    abstract public bool CanActivate();
    abstract public void Activate();

}

/*public class Move
{
    //private MoveManager _manager;
    public MoveData Data;


    public Move(MoveData data) {
        Data = data;
    }

    public bool Evaluate(PlayerManager playerManager) {
        // Determine pool
        List<Dice> pool = GetPool(playerManager);
        if (pool == null || pool.Count == 0) return false;

        // Check conditions
        return EvaluateConditions(pool);
    }

    private List<Dice> GetPool(PlayerManager player) {
        switch (Data.Type) {
            case MoveType.Active:
                return player.DiceManager.Selected;
            case MoveType.Passive:
                return player.DiceManager.Hand;
            case MoveType.Counter:
                return player.EnemyManager.DiceManager.Hand;
            default:
                return null;
        }
    }
    public bool EvaluateConditions(List<Dice> pool) {
        // Enough dice?
        int size = 0;
        foreach (Condition c in Data.Conditions) size += c.Size;
        if (size != pool.Count) return false;

        // Build frequency map
        int[] frequencyMap = new int[DiceFaceData.MAX_DICE_VALUE * 2 + 1 + DiceFaceData.ELEMENT_COUNT];
        foreach (Dice d in pool) {
            ++frequencyMap[d.CurrentFace.Number + DiceFaceData.MAX_DICE_VALUE + DiceFaceData.ELEMENT_COUNT];
            ++frequencyMap[(int)d.CurrentFace.Type];
        }

        // Check conditions
        List<int[]> oldMaps = new List<int[]>();
        oldMaps.Add(new int[DiceFaceData.MAX_DICE_VALUE * 2 + 1 + DiceFaceData.ELEMENT_COUNT]);
        foreach (Condition c in Data.Conditions) {
            // Track running total maps
            List<int[]> newMaps = new List<int[]>();
            // Build cost maps and check each
            foreach (int[] costMap in c.Eval(frequencyMap)) {
                foreach (int[] totalMap in oldMaps) {
                    // Check for early overflow
                    int[] newMap = AddMaps(costMap, totalMap);
                    if (GreaterThan(newMap, frequencyMap)) continue;
                    newMaps.Add(newMap);
                }
            }
            // Update running total maps
            if (newMaps.Count == 0) return false;
            oldMaps = newMaps;
        }
        //Find passing cost map
        foreach (int[] costMap in oldMaps) if (EqualTo(costMap, frequencyMap)) return true;
        return false;
    }
    private int[] AddMaps(int[] a, int[] b) {
        if (a.Length != b.Length) return null;
        int[] ret = new int[a.Length];
        for (int i = 0; i < a.Length; i++) ret[i] = a[i] + b[i];
        return ret;
    }
    // Is A greater than B
    private bool GreaterThan(int[] a, int[] b) {
        if (a.Length != b.Length) return true;
        bool greaterThan = false;
        for (int i = 0; i < a.Length; i++) {
            if (a[i] > b[i]) {
                greaterThan = true;
                break;
            }
        }
        return greaterThan;
    }
    private bool EqualTo(int[] a, int[] b) {
        if (a.Length != b.Length) return false;
        bool equals = true;
        for (int i = 0; i < a.Length; i++) {
            if (a[i] != b[i]) {
                equals = false;
                break;
            }
        }
        return equals;
    }

    public void Use() {

    }
}*/

/*using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public abstract class Move : MonoBehaviour
{
    private MoveBar _moveBar;
    [SerializeField] protected string _name;
    [SerializeField] protected Sprite _cost;
    [SerializeField] protected string _description;
    public MoveType Type { get; private set;}

    [SerializeField] protected bool _canUse;

    void Awake() {
        _moveBar = GetComponent<MoveBar>();
    }

    void Start() {
        if (Type == MoveType.Active) _moveBar.Setup(_name, _cost, _description, Use);
        else _moveBar.Setup(_name, _cost, _description, Type);
    }

    void Update() {
        if (Type == MoveType.Active) _moveBar.SetUseIcon(CanUseEval(CombatManager.Instance.SelectedDice));
    }

    abstract public bool CanUseEval(List<Dice> selected);

    abstract public void Use();

    public string GetName() { return _name; }
    public override bool Equals(object obj) {
        return obj is Move && ((Move)obj).GetName() == _name;
    }
}


*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using JetBrains.Annotations;
using System;
using Unity.VisualScripting;
using System.Linq;

//[CreateAssetMenu(fileName = "Move", menuName = "ScriptableObjects/Move", order = 3)]
public abstract class MoveData : ScriptableObject
{
    public string Name = "";
    public Sprite CostSprite = null;
    public string Description = "";
    virtual public MoveType Type { get; }

}
public enum MoveType
{
    Active,
    Passive,
    Counter
}


/*public class MoveData : ScriptableObject
{
    public string Name = "";
    public Sprite Cost = null;
    public string Description = "";
    public MoveType Type = MoveType.Active;
    [SerializeField] private Straight[] StraightConditions = new Straight[0];
    [SerializeField] private Match[] MatchConditions = new Match[0];
    public Condition[] Conditions { 
        get {
            Condition[] ret = new Condition[StraightConditions.Length + MatchConditions.Length];
            MatchConditions.CopyTo(ret, 0);
            StraightConditions.CopyTo(ret, MatchConditions.Length);
            return ret;
        } 
    }

    // Effects:
    public bool SpendDice = false;

    public bool AddDice = false;
    public DiceData[] DiceToAdd = new DiceData[0];

    public int Damage = 0;
    public int Heal = 0;
    public int Shield = 0;

    public Status[] StatusToSelf;
    public Status[] StatusToEnemy;

}*/
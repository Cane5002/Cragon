using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroData : ScriptableObject
{
    public string Name;
    public List<string> Moves;
    public List<DiceData> Dice;
}

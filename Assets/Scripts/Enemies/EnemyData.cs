using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 3)]
public class EnemyData : ScriptableObject
{
    public string Name;
    public int Health;
    public int Level;
    public List<DiceData> Dice;
    public List<string> Moves;
}

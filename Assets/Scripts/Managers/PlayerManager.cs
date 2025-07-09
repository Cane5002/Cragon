using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{ 
    public DiceManager DiceManager;
    public MoveManager MoveManager;
    public PlayerManager EnemyManager;
    [SerializeField] private HealthBar _healthBar;



    public void SetHealth(int health) { _healthBar.SetMaxHealth(health); _healthBar.SetHealth(health); }
    public void DealDamage(int damage) { _healthBar.DealDamage(damage); }
    public void HealDamage(int healAmount) { _healthBar.HealDamage(healAmount); }



    /*public void UsePassives(List<Dice> hand) {
        foreach (Move move in _moves) {
            if (move.Type == MoveType.Passive && move.CanUseEval(hand)) move.Use();
        }
    }*/

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : Singleton<CombatManager>
{
    // Player
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private GameObject _playerBoard;
    [SerializeField] private Button _endPlayerTurnButton;


    //Enemy
    [SerializeField] private PlayerManager _enemyManager;
    [SerializeField] private GameObject _enemyBoard;
    [SerializeField] private Button _endEnemyTurnButton;


    public CombatPhase CurrentPhase { get; private set; }

    public void StartCombat(EnemyData enemy) {
        Debug.Log("Beginning Combat...");
        _enemyManager.DiceManager.Equip(enemy.Dice);
        _enemyManager.DiceManager.LoadDice();
        //_enemyManager.MoveManager.ClearMoves();
        //_enemyManager.MoveManager.AddMoves(enemy.Moves);

        _playerManager.DiceManager.LoadDice();


        HandlePlayerTurn();
    }

    public void HandlePlayerTurn() {
        CurrentPhase = CombatPhase.PlayerTurn;
        _playerManager.DiceManager.RefreshRolls();
        _endPlayerTurnButton.interactable = true;
    }
    public void EndPlayerTurn() {
        _endPlayerTurnButton.interactable = false;
        _playerManager.DiceManager.ResetDice();
        HandleEnemyTurn();
    }

    public void HandleEnemyTurn() {
        CurrentPhase = CombatPhase.EnemyTurn;
        _enemyManager.DiceManager.RefreshRolls();
        _endEnemyTurnButton.interactable = true;
    }
    public void EndEnemyTurn() {
        _endEnemyTurnButton.interactable = false;
        _enemyManager.DiceManager.ResetDice();
        HandlePlayerTurn();
    }

    public void Victory() {
        Debug.Log("Player wins");
    }

    public void Defeat() {
        Debug.Log("Player loses");
    }
}

public enum CombatPhase
{
    PlayerTurn,
    EnemyTurn,
    Victory,
}
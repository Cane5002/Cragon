using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public GamePhase CurrentPhase { get; private set; }

    [SerializeField] private PlayerManager _playerManager;

    // Menu
    [SerializeField] private Canvas _menuCanvas;

    // Hero Select
    [SerializeField] private Canvas _heroSelectCanvas;

    // Combat
    [SerializeField] private Canvas _combatCanvas;
    public EnemyData testEnemy;

    private void Start() {
        HandleCombat();
        //HandleMenu();
    }

    public void HandleMenu() {
        CurrentPhase = GamePhase.Menu;
        _menuCanvas.enabled = true;
    }

    public void HandleHeroSelect() {
        CurrentPhase = GamePhase.HeroSelect;
        _heroSelectCanvas.enabled = true;
    }

    public void SelectHero(HeroData heroData) {
        _menuCanvas.enabled = false;
        _heroSelectCanvas.enabled = false;
        //_playerManager.AddMoves(heroData.Moves);
        _playerManager.DiceManager.Equip(heroData.Dice);
        HandleCombat();
    }

    public void HandleCombat() {
        CurrentPhase = GamePhase.Combat;
        _combatCanvas.enabled = true;
        CombatManager.Instance.StartCombat(testEnemy);
    }
}

public enum GamePhase
{
    Menu,
    HeroSelect,
    Map,
    Combat,
    Shop,
    Rest,
    Defeat,
}

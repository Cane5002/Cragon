using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    [SerializeField] private GameObject _movePrefab;
    [SerializeField] private GameObject _moveList;
    [SerializeField] private List<Move> _moves;
    public void AddMove(string move) {
        GameObject inst = Instantiate(_movePrefab, _moveList.transform);
        inst.AddComponent(MoveDictionary.GetMove(move));
        _moves.Add(inst.GetComponent<Move>());
    }
    public void AddMove(List<string> moves) {
        foreach (string move in moves) { AddMove(move); }
    }
    public void RemoveMove(Move move) {
        int index = _moves.IndexOf(move);
        //_moves[index];
        _moves.RemoveAt(index);
    }
    public void ClearMoves() {
        foreach (Transform child in _moveList.transform) {
            Destroy(child.gameObject);
        }
        _moves.Clear();
    }
}

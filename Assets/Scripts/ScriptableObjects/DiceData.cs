using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName="Dice", menuName="ScriptableObjects/Dice", order = 1)]
public class DiceData : ScriptableObject
{
    public Color Color;
    public string Name;
    public int FaceCnt;
    public DiceFaceData[] Faces;

    
    public DiceFaceData GetRandomFace() {
        return Faces[Random.Range(0, FaceCnt)];
    }

    public override bool Equals(object obj) {
        return obj is DiceData && ((DiceData)obj).Name == Name;
    }

    public override int GetHashCode() {
        return Name.GetHashCode();
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "DiceFace", menuName = "ScriptableObjects/DiceFace", order = 2)]
public class DiceFaceData : ScriptableObject {
    public FaceType FaceType;

    public Sprite Image;
    public int Number;
    public Element Type;
    public int Quantity;

    public const int MAX_DICE_VALUE = 20;
    public const int ELEMENT_COUNT = 7;
}

public enum FaceType
{
    Normal,
    Dual
}

public enum Element {
    None,
    Death,
    Water,
    Air,
    Earth,
    Fire,
    Life
}

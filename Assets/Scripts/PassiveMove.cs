using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassiveMove : Move
{
    public override MoveType Type { get { return MoveType.Passive; } }
}

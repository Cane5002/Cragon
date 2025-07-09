using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CounterMove : Move
{
    public override MoveType Type { get { return MoveType.Counter; } }

}

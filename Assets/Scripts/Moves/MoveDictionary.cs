using System;
using System.Collections;
using System.Collections.Generic;

public static class MoveDictionary
{
    private static Dictionary<string, System.Type> dict = new Dictionary<string, System.Type>() {
        { "Strike", typeof(Strike) },
        { "MagicMissile", typeof(MagicMissile) },
        { "Tackle", typeof(Tackle) },
        { "BodySlam", typeof(BodySlam) },
        { "Bite", typeof(Bite) },
        { "Ambush", typeof(Ambush) },
    };

    public static System.Type GetMove(string move) {
        return dict[move];
    }
}
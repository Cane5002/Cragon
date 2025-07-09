using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tackle : ActiveMove {
    public override bool CanActivate() {
        return true;
    }

    public override void Activate() {
        Debug.Log("Tackle");
    }

}

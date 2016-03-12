using UnityEngine;
using System.Collections.Generic;

public class BigBrother : MonoBehaviour {

    private List<Node> nodes;
    public int ownedByPlayer = 0;
    
    public void notify() {
        foreach(Node n in nodes) {
            if (!n.isUsed()) { return; }
        }
        GameStateManager gsm = GameStateManager.getInstance();
        ownedByPlayer = gsm.getState();
    }

}

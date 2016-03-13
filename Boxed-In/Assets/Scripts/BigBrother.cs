using UnityEngine;
using System.Collections.Generic;

public class BigBrother : MonoBehaviour {


    private List<Node> cubeNodes = new List<Node>();
    public int ownedByPlayer = 0;
    public int numOfNodes = 0;

    public void notify() {
        foreach (Node n in cubeNodes) {
            if (!n.isUsed()) { return; }
        }
        GameStateManager gsm = GameStateManager.getInstance();
        ownedByPlayer = gsm.getState();
    }

    public void OnTriggerEnter(Collider other) {
        GameObject go = other.gameObject;
        Node n = go.GetComponent<Node>();

        if(n == null) { return; }
        n.addBigBorther(this);
        cubeNodes.Add(n);
        numOfNodes++;
    }

    public void OnTriggerStay(Collider other) {
        Collider c = this.GetComponent<Collider>();
        c.enabled = false;
    }


}

using UnityEngine;
using System.Collections.Generic;

public class BigBrother : MonoBehaviour {

    private List<Node> cubeNodes = new List<Node>();
    public int ownedByPlayer = 0;
    public int numOfNodes = 0;

    //Todo Make the BigO runtime of notfy better. 
    public void notify() {
        foreach (Node n in cubeNodes) {
            if (isConectedTo(n.getConnectedNeighbors() ) ) { return; }
        }
        GameStateManager gsm = GameStateManager.getInstance();
        ownedByPlayer = gsm.getPlayerState();
        gsm.incromentScore(ownedByPlayer);
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

    /* flag needs to be 3 because each box has to beconected to at min 3 of the 
    samenodes of the 8 in bigBrother;
     */
    private bool isConectedTo(List<Node> neighbors) {
        int flag = 0;
        foreach (Node n in cubeNodes) {
            if (neighbors.Contains(n)) {
                flag++;
            }
        }
        return (flag == 3);
    }
}

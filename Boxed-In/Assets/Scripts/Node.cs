using UnityEngine;
using System.Collections.Generic;

public class Node : MonoBehaviour {

    private List<BigBrother> observer = new List<BigBrother>();
    private List<Node> connectedNeighbors = new List<Node>();
    private bool used = false;
    private bool connected = false;

    public int scale = 1;
    private int state = 0;
    public Material normalMat;
    public Material selectedMat;


    public bool isUsed() { return used; }
    public void setUsed(bool used) { this.used = used; }
    public int getState() { return state; }
    public void setState(int state) { this.state = state; }

    public void fireEvent() {
        state++;
        foreach (BigBrother bb in observer) {
            bb.notify();
        }
    }

    public void addBigBorther(BigBrother b) {
        observer.Add(b);
    }
    public void addConnectedNeighbors(Node n) {
        connectedNeighbors.Add(n);
    }
    public List<Node> getConnectedNeighbors() {
        return connectedNeighbors;
    }

    public bool isNodeSelected() {
        return false;
    }

}

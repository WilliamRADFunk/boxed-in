using UnityEngine;
using System.Collections.Generic;

public class Node : MonoBehaviour {

    private List<BigBrother> observer = new List<BigBrother>();
    private bool used = false;
    public int scale = 1;
    private int state = 0;
    public Material normal;
    public Material selected;


    public bool isUsed() { return used; }
    public void setUsed(bool used) { this.used = used; }
    public int getState() { return state; }
    public void setState(int state) { this.state = state;}

    public void fireEvent() {
        state++;
        foreach(BigBrother bb in observer) {
            bb.notify();
        }
    }

    public bool isNodeSelected() {
        return false;
    }
}

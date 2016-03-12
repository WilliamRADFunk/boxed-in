using UnityEngine;
using System.Collections.Generic;

public class GameBoardGenerator : MonoBehaviour {

    public int boardSize = 4;
    public int space = 2;
    public GameObject node;
    public GameObject test;

    private List<BigBrother> bigBrothers = new List<BigBrother>();
    private List<Node> nodes = new List<Node>();

    public void Awake() {
        populateGraph_Nodes();
       // populateGraph_BigBrothers();
    }

    public List<Node> getNodes() { return nodes; }
    public List<BigBrother> getBigBrothers() { return bigBrothers; }

    private void populateGraph_Nodes() {
        for (int i = (int)-(boardSize / 2); i < (int)(boardSize / 2); i++) {
            for (int j = (int)-(boardSize / 2); j < (int)(boardSize / 2); j++) {
                int counter = 1;
                for (int k = (int)-(boardSize / 2); k < (int)(boardSize / 2); k++) {
                    GameObject go = (GameObject)Instantiate(node, new Vector3(i * space, j * space, k * space), Quaternion.identity);
                    go.transform.SetParent(this.transform);
                    go.name = "node";
                    Node n = go.GetComponent<Node>();
                    nodes.Add(n);
                    if(k> (int)-(boardSize / 2) && counter % 4 == 0) {
                        counter = 1;
                        GameObject bb = (GameObject)Instantiate(test, new Vector3(i, j, k), Quaternion.identity);
                        bb.transform.SetParent(this.transform);
                        bb.name = "test";
                    }
                    else {
                        counter++;
                    }
                }
            }
        }
    }

    /*
    private void populateGraph_BigBrothers() {
        Debug.Log((int)-(boardSize - 1) / 2);
        for (int i = (int)-(boardSize-1)/2; i < (int)(boardSize - 1) / 2; i++) {
            for (int j = (int)-(boardSize - 1) / 2; j < (int)(boardSize - 1) / 2; j++) {
                for (int k = (int)-(boardSize - 1) / 2; k < (int)(boardSize - 1) / 2; k++) {
                    GameObject go = (GameObject)Instantiate(test, new Vector3(i, j , k ), Quaternion.identity);
                    go.transform.SetParent(this.transform);
                    go.name = "test";
                    Node n = go.GetComponent<Node>();
                    nodes.Add(n);
                }
            }
        }
    }
    */
}

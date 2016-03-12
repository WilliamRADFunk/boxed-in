﻿using UnityEngine;
using System.Collections.Generic;

public class GameBoardGenerator : MonoBehaviour {

    public int boardSize = 4;
    public int space = 2;
    public GameObject node;

    private List<BigBrother> bigBrothers = new List<BigBrother>();
    private List<Node> nodes = new List<Node>();

    public void Awake() {
        populateGraph();
    }

    public List<Node> getNodes() { return nodes; }
    public List<BigBrother> getBigBrothers() { return bigBrothers; }

    private void populateGraph() {
        for (int i = (int)-(boardSize / 2); i < (int)(boardSize / 2); i++) {
            for (int j = (int)-(boardSize / 2); j < (int)(boardSize / 2); j++) {
                for (int k = (int)-(boardSize / 2); k < (int)(boardSize / 2); k++) {
                    GameObject go = (GameObject)Instantiate(node, new Vector3(i * space, j * space, k * space), Quaternion.identity);
                    go.transform.SetParent(this.transform);
                    go.name = "node";
                    Node n = go.GetComponent<Node>();
                    nodes.Add(n);
                }
            }
        }
    }
}

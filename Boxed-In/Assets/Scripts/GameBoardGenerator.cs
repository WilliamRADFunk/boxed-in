using UnityEngine;
using System.Collections.Generic;

public class GameBoardGenerator : MonoBehaviour
{

    public int boardSize = 4;
    public int space = 2;
    private float skew;
    public GameObject node;
    public GameObject test;

    private List<BigBrother> bigBrothers = new List<BigBrother>();
    private List<Node> nodes = new List<Node>();

    public void Awake()
    {
        if (boardSize % 2 == 0)
        {
            skew = space / 2;
        }
        else
        {
            skew = 0f;
        }
        populateGraph_Nodes();
        populateGraph_BigBrother();
    }

    public List<Node> getNodes() { return nodes; }
    public List<BigBrother> getBigBrothers() { return bigBrothers; }

    private void populateGraph_Nodes()
    {

        for (int i = (int)-(boardSize / 2); i < (int)(boardSize / 2); i++)
        {
            for (int j = (int)-(boardSize / 2); j < (int)(boardSize / 2); j++)
            {
                for (int k = (int)-(boardSize / 2); k < (int)(boardSize / 2); k++)
                {
                    GameObject go = (GameObject)Instantiate(node, new Vector3(i * space + skew, j * space + skew, k * space + skew), Quaternion.identity);
                    Debug.Log(i + " " + j + " " + k);
                    go.transform.SetParent(this.transform);
                    go.name = "node";
                    Node n = go.GetComponent<Node>();
                    nodes.Add(n);
                }
            }
        }
    }


    private void populateGraph_BigBrother()
    {
        for (int i = (int)-(boardSize / 2); i < (int)(boardSize / 2); i++)
        {
            for (int j = (int)-(boardSize / 2); j < (int)(boardSize / 2); j++)
            {
                for (int k = (int)-(boardSize / 2); k < (int)(boardSize / 2); k++)
                {
                    if (i == (int)(boardSize / 2) - 1 ||
                        j == (int)(boardSize / 2) - 1 ||
                        k == (int)(boardSize / 2) - 1)
                    { }
                    else
                    {
                        GameObject bb = (GameObject)Instantiate(test, new Vector3(i * space + (2 * skew), j * space + (2 * skew), k * space + (2 * skew)), Quaternion.identity);
                        bb.transform.SetParent(this.transform);
                        bb.name = "BigBrother";
                    }
                }
            }
        }
    }
}
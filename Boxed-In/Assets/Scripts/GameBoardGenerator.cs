using UnityEngine;
using System.Collections.Generic;

public class GameBoardGenerator : MonoBehaviour
{

    public int boardSize = 4;
    public int space = 2;
    private int bounds;
    private float skew;
    private bool even;
    public GameObject node;
    public GameObject test;

    private List<BigBrother> bigBrothers = new List<BigBrother>();
    private List<Node> nodes = new List<Node>();

    public void Awake()
    {
        skew = space / 2;
        if (boardSize % 2 == 0)
        {
            even = true;
            
        }
        else
        {
            even = false;
        }
        bounds = Mathf.FloorToInt(boardSize / 2);
        Debug.Log(bounds);
        populateGraph_Nodes();
        populateGraph_BigBrother();
    }

    public List<Node> getNodes() { return nodes; }
    public List<BigBrother> getBigBrothers() { return bigBrothers; }

    private void populateGraph_Nodes()
    {

        if(even)
        {
            for (int i = (int)-bounds; i < bounds; i++)
            {
                for (int j = (int)-bounds; j < bounds; j++)
                {
                    for (int k = (int)-bounds; k < bounds; k++)
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
        else
        {
            for (int i = (int)-bounds; i < bounds + 1; i++)
            {
                for (int j = (int)-bounds; j < bounds + 1; j++)
                {
                    for (int k = (int)-bounds; k < bounds + 1; k++)
                    {
                        GameObject go = (GameObject)Instantiate(node, new Vector3(i * space, j * space, k * space), Quaternion.identity);
                        Debug.Log(i + " " + j + " " + k);
                        go.transform.SetParent(this.transform);
                        go.name = "node";
                        Node n = go.GetComponent<Node>();
                        nodes.Add(n);
                    }
                }
            }
        }
    }


    private void populateGraph_BigBrother()
    {
        if(even)
        {

            for (int i = (int)-bounds; i < bounds; i++)
            {
                for (int j = (int)-bounds; j < bounds; j++)
                {
                    for (int k = (int)-bounds; k < bounds; k++)
                    {
                        if (i == bounds - 1 ||
                            j == bounds - 1 ||
                            k == bounds - 1)
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
        else
        {
            for (int i = (int)-bounds; i < bounds + 1; i++)
            {
                for (int j = (int)-bounds; j < bounds + 1; j++)
                {
                    for (int k = (int)-bounds; k < bounds + 1; k++)
                    {
                        if (i == bounds ||
                            j == bounds ||
                            k == bounds )
                        { }
                        else
                        {
                            GameObject bb = (GameObject)Instantiate(test, new Vector3(i * space + skew, j * space + skew, k * space + skew), Quaternion.identity);
                            bb.transform.SetParent(this.transform);
                            bb.name = "BigBrother";
                        }
                    }
                }
            }
        }
    }
}
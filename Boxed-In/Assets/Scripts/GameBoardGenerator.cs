using UnityEngine;
using System.Collections;

public class GameBoardGenerator : MonoBehaviour {

    public int boardSize = 4;
    public int space = 2;
    public GameObject node;

    public void Awake() {
        for (int i = (int)-(boardSize/2); i < (int)(boardSize / 2); i++){
            for (int j = (int)-(boardSize / 2); j < (int)(boardSize / 2); j++) {
                for (int k = (int)-(boardSize / 2); k < (int)(boardSize / 2); k++) {
                    GameObject n = (GameObject) Instantiate(node, new Vector3(i*space, j * space, k * space), Quaternion.identity);
                    n.transform.SetParent(this.transform);
                    n.name = "node";
                }
            }
        }
    }
}

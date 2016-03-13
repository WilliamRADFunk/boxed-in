using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    private GameStateManager gsm;
    public Camera camera;
    public GameObject slectedObject;

    public void Awake() {
        gsm = GameStateManager.getInstance();
    }

    // Update is called once per frame
    void Update() {
        selectNode();
        /*
        switch (gsm.getState()) {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                selectNode();
                break;
        }
        */
    }

    void selectNode() {

        if (!Input.GetMouseButton(0)) { return; }
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit)) {
            GameObject objectHit = hit.transform.gameObject;
            slectedObject = objectHit;
            Node n = slectedObject.GetComponent<Node>();
            Renderer r = slectedObject.GetComponent<Renderer>();
            r.material = n.selectedMat;
        }
        else {
            if(slectedObject != null) {
                Node n = slectedObject.GetComponent<Node>();
                Renderer r = slectedObject.GetComponent<Renderer>();
                r.material = n.normalMat;
            }
        }
    }

    void conectNode() {

    }
}

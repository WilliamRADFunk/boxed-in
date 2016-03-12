using UnityEngine;
using System.Collections;

public class GameStateManager {

    private static GameStateManager instance;
    private int state = 1;

    private GameStateManager() { }

    public static GameStateManager getInstance() {
        if(instance == null) {
            instance = new GameStateManager();
        }
        return instance;
    }

    public int getState() { return state; }
    public void setState(int state) { this.state = state; }

}

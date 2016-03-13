using UnityEngine;
using System.Collections;

public class GameStateManager {

    private static GameStateManager instance;
    public int player1 = 0;
    public int player2 = 0;

    private int playerState = 1;

    private int state = 0;

    private GameStateManager() { }

    public static GameStateManager getInstance() {
        if(instance == null) {
            instance = new GameStateManager();
        }
        return instance;
    }

    public int getPlayerState() { return state; }
    public void setPlayerState(int state) { this.state = state; }


    public int getState() { return state; }
    public void setState(int state) { this.state = state; }

    public int getPLayerScore() { return player1; }
    public void incromentScore(int player) {
        if(player == 1) {
            player1++;
        }
        else {
            player2++;
        }
    }
}

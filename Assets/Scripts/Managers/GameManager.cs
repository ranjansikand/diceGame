// Handles a game instance
// Switches between gameplay, shop, and game over states


using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int scoreThreshold { get; private set; } = 20;

    private void Start() {
        StartCoroutine(Gameplay());
    }

    IEnumerator Gameplay() {
        while (!PlayerLost()) {
            RoundManager round = new RoundManager(this);
            yield return new WaitUntil(() => round.complete);
        }

        Debug.Log("Player lost. Lost on rolls? " 
            + (PlayerData.rolls <= 0) 
            + ". Lost on points? " + (PlayerData.score < scoreThreshold) + "."
        );
    }

    bool PlayerLost() {
        return PlayerData.rolls <= 0 && PlayerData.score < scoreThreshold;
    }
}

// Handles a single round
// Creates rolls and calculates the round payout (if applicable)


using System.Collections;
using UnityEngine;

public class RoundManager
{
    GameManager gm;

    public bool complete = false;

    public RoundManager(GameManager gm) {
        this.gm = gm;
        
        // Reset data
        GameManager.roundScore = GameManager.scoreThreshold;
        PlayerData.rolls = PlayerData.maxRolls;
        gm.player.SpawnDice();


        gm.StartCoroutine(Round());
    }

    IEnumerator Round() {
        while (!RoundComplete()) {
            RollManager roll = new RollManager(gm, this);
            yield return new WaitUntil(() => roll.complete);
        }

        Debug.Log("Round complete");
        yield return new WaitForSeconds(0.5f);

        // Payout
        if (GameManager.roundScore <= 0) {
            Finance.PayPlayer();
            yield return new WaitForSeconds(1f);
        }
        

        complete = true;
    }

    bool RoundComplete() {
        return (PlayerData.rolls <= 0 || GameManager.roundScore <= 0);
    }
}

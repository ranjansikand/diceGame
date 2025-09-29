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
        PlayerData.score = 0;
        PlayerData.rolls = PlayerData.maxRolls;


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
        if (PlayerData.score >= GameManager.scoreThreshold) {
            Payroll.Payout();
            yield return new WaitForSeconds(1f);
        }
        

        complete = true;
    }

    bool RoundComplete() {
        return (PlayerData.rolls <= 0 || PlayerData.score >= GameManager.scoreThreshold);
    }
}

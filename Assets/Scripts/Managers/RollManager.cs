// Handles a single roll
// Rolls the dice and counts their score


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollManager
{
    GameManager gm;
    RoundManager rm;

    public bool complete = false;
    List<int> diceValues = new List<int>();

    public RollManager(GameManager gm, RoundManager rm) {
        this.gm = gm;
        this.rm = rm;

        gm.StartCoroutine(Roll());
    }

    IEnumerator Roll() {
        yield return WaitToRoll();
        yield return new WaitUntil(() => DiceHaveSettled());
        yield return ScoreTheDice();

        // Tabulate the score
        GameManager.roundScore -= PlayerData.score;
        PlayerData.score = 0;
        
        PlayerData.performRoll = false;
        complete = true;
    }

    // Wait for input then roll dice
    IEnumerator WaitToRoll() {
        // Do not roll if unable
        if (PlayerData.rolls <= 0) { 
            complete = true;
            yield break;
        }

        // Wait for input
        yield return new WaitUntil(() => PlayerData.performRoll);
        PlayerData.rolls -= 1;

        // Perform the roll
        foreach (Dice dice in Player.dice) {
            dice.RollDice();
        }

        PlayerData.performRoll = false;
    }


    // Display the final score
    IEnumerator ScoreTheDice() {
        foreach (Dice die in Player.dice) die.CalculateValue();
        yield return Data.halfSecond;

        Player.OrganizeDice();
        yield return Data.quarterSecond;

        yield return Score.Calculate();
    }

    // Check if the dice are still moving
    bool DiceHaveSettled() {
        foreach (Dice dice in Player.dice) {
            if (!dice.hasSettled) return false;
        }

        return true;
    }
}

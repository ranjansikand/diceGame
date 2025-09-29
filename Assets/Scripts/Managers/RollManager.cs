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

    public RollManager(GameManager gm, RoundManager rm) {
        this.gm = gm;
        this.rm = rm;

        gm.StartCoroutine(WaitToRoll());
    }

    // Check if the dice are still moving
    bool DiceHaveSettled() {
        foreach (Dice dice in PlayerData.dice) {
            if (!dice.hasSettled) return false;
        }

        return true;
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
        foreach (Dice dice in PlayerData.dice) {
            dice.RollDice();
        }

        PlayerData.performRoll = false;
        gm.StartCoroutine(CountDice());
    }


    // Wait for the roll to finish and count the dice
    IEnumerator CountDice() {
        yield return new WaitUntil(() => DiceHaveSettled());

        List<int> diceValues = new List<int>();
        foreach (Dice dice in PlayerData.dice) {
            // Dice value
            int diceValue = dice.CalculateValue();
            diceValues.Add(diceValue);

            yield return new WaitForSeconds(0.25f);
        }

        yield return ScoreTheDice(diceValues);
    }

    // Display the final score
    IEnumerator ScoreTheDice(List<int> diceValues) {
        yield return new WaitForSeconds(0.5f);

        PlayerData.score += Score.Calculate(diceValues);
        PlayerData.performRoll = false;
        complete = true;
    }
    
}

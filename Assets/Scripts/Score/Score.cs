// Checks the score


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score
{
    public static IEnumerator Calculate() {
        yield return Sum();
        yield return Data.quarterSecond;
        yield return Cards();
        yield return Data.halfSecond;
    }

    private static IEnumerator Sum() {
        foreach (Dice die in PlayerData.dice) {
            PlayerData.score += die.CalculateValue();
            yield return Data.quarterSecond;
        }
    }

    private static IEnumerator Cards() {
        foreach (Card card in CardDisplay.displayedCards) {
            yield return card.Check();
        }
    }
}

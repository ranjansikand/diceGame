// Checks the score


using System.Collections;
using System.Collections.Generic;

public static class Score
{
    public static IEnumerator Calculate() {
        yield return Sum();

        yield return Data.halfSecond;

        PlayerData.score = PlayerData.pointValue * PlayerData.multiplier;
    }

    private static IEnumerator Sum() {
        foreach (Dice die in PlayerData.dice) {
            PlayerData.pointValue += die.CalculateValue();
            yield return null;
        }
    }
}

// Checks the score


using System.Collections;

public static class Score
{
    public static IEnumerator Calculate() {
        yield return Sum();
        yield return Data.quarterSecond;
        yield return Cards();
        yield return Data.halfSecond;
    }

    private static IEnumerator Sum() {
        foreach (Dice die in Player.dice) {
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

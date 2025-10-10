// Checks the score


using System.Collections;

public static class Score
{
    public static IEnumerator Calculate() {
        yield return ScoreDice();
        yield return ScoreCards();
        yield return Data.halfSecond;
    }

    private static IEnumerator ScoreDice() {
        foreach (Dice die in Player.dice) {
            yield return die.Score();
        }
    }

    private static IEnumerator ScoreCards() {
        foreach (Card card in CardDisplay.displayedCards) {
            yield return card.Check();
        }
    }
}

// Die that becomes better with experience


using System.Collections;

public class SageDie : DiceData
{
    public override IEnumerator Score(Dice die) {
        if (die.timesRolled > 0) {
            // Visuals!
            if (Dice.bonus != null) Dice.bonus(die, "+" + die.timesRolled);
            yield return Data.quarterSecond;
        }

        PlayerData.score += (die.value + die.timesRolled);
        yield return Data.quarterSecond;
    }
}

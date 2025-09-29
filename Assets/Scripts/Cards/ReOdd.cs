// Rerolls odd dice


using System.Collections.Generic;

public class ReOdd : Card
{
    List<Dice> rerolledDice = new List<Dice>();

    private void OnEnable() {
        Dice.valueCalculated += RerollDice;
    }

    private void OnDisable() {
        Dice.valueCalculated -= RerollDice;
    }

    private void RerollDice(Dice dice) {
        if (dice.value % 2 == 1 && !rerolledDice.Contains(dice)) {
            dice.RollDice();
            rerolledDice.Add(dice);
        }
    }
}

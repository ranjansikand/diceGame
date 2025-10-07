// Die with a team-up bonus


using System.Collections;
using DG.Tweening;
using UnityEngine;

public class LegionDie : DiceData
{
    public override IEnumerator Score(Dice die) {
        // Count other legionnaries!
        int count = 0;
        foreach (Dice dieToCheck in Player.dice) {
            if (dieToCheck.diceData.GetType() == typeof(LegionDie) && dieToCheck != die) {
                count++;

                // Visuals!
                if (Dice.bonus != null) Dice.bonus(dieToCheck, "+1");
                dieToCheck.transform.DOScale(Vector3.one * 1.05f, 0.125f)
                    .OnComplete(() => dieToCheck.transform.DOScale(Vector3.one, 0.075f));

                yield return Data.quarterSecond;
            }
        }

        if (count > 0) yield return Data.halfSecond;

        PlayerData.score += (die.value + count);
        yield return Data.quarterSecond;
    }
}

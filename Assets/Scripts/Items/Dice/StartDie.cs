// Die that rescores the previous scored die


using System.Collections;
using UnityEngine;

public class StartDie : DiceData
{
    public override IEnumerator Score(Dice die) {
        int currentIndex = Player.dice.IndexOf(die);

        if (currentIndex - 1 >= 0 && Player.dice[currentIndex - 1] != null) {
            yield return Data.quarterSecond;
            Debug.Log("Scoring " + Player.dice[currentIndex - 1]);
            yield return Player.dice[currentIndex - 1].Score();
        }
            

        PlayerData.score += die.value;
        yield return Data.quarterSecond;
    }
}

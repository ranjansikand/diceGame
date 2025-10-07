// Data for a specific dice


using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Die", menuName = "Items/Dice", order = 0)]
public class DiceData : Item {
    public int[] values = new int[6] { 2, 1, 3, 5, 6, 4 };

    public virtual IEnumerator Score(Dice die) {
        PlayerData.score += die.value;
        yield return Data.quarterSecond;
    }
}


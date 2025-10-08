// Data for a specific dice


using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Die", menuName = "Items/Dice", order = 0)]
public class DiceData : Item {
    // Order: [0]=forward, [1]=up, [2]=right, [3]=back, [4]=down, [5]=left
    public int[] values = new int[6] { 2, 1, 3, 5, 6, 4 };

    public virtual IEnumerator Score(Dice die) {
        PlayerData.score += die.value;
        yield return Data.quarterSecond;
    }
}


// Data for a specific dice


using UnityEngine;

[CreateAssetMenu(fileName = "New Die", menuName = "Items/Dice", order = 0)]
public class DiceData : Item {
    public int[] values = new int[6] { 2, 1, 3, 5, 6, 4 };
}


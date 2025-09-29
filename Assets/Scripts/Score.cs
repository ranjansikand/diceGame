// Calculate the scores


using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Score {

    public static int Calculate(List<int> dice) {
        int sum = dice.Sum();
        
        return sum;
    }

    private static bool CheckForDoubles(List<int> dice, int i) {
        for (int j = 0; j < dice.Count; j++) {
            if (j != i && dice[j] == dice[i]) return true;
        }

        return false;
    }

    private static bool CheckSequence(List<int> dice, int i) {
        for (int j = 0; j < dice.Count; j++) {
            if (Mathf.Abs(dice[j] - dice[i]) == 1) return true;
        }

        return false;
    }
}

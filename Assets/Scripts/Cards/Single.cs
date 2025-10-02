// Card with a single check condition


using System.Collections;
using UnityEngine;

public class Single : Card
{
    [SerializeField] protected Operator op;
    [SerializeField] protected int amount;
    [SerializeField, Range(1, 6)] protected int condition = 1;

    public override IEnumerator Check() {
        foreach (Dice die in PlayerData.dice) {
            if (die.CalculateValue() == condition) {
                AddOperator();
                yield return Data.quarterSecond;
            }
        }
    }

    protected void AddOperator() {
        switch (op) {
            case (Operator.Points): PlayerData.score += amount; break;
            case (Operator.Multipier): PlayerData.score *= amount; break;
            case (Operator.Rerolls): PlayerData.rolls += amount; break;
            case (Operator.Money): PlayerData.money += amount; break;
            default: break;
        }
    }
}

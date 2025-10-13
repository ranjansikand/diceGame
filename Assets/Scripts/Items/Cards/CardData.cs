// Card that can be collected
// Impacts scoring


using System.Collections;
using UnityEngine;


[CreateAssetMenu(fileName = "New Card", menuName = "Items/Card", order = 1)]
public class CardData : Item
{
    public override Type type { get { return Type.Card; }}

    public virtual IEnumerator Check(Card card) {
        yield return null;
    }

    protected void Perform(Operator op, int amount, Dice die) {
        switch (op) {
            case (Operator.Points): {
                PlayerData.score += amount; 
                Dice.bonus(die, "+" + amount);
                break;
            }
            case (Operator.Multipier): {
                PlayerData.score *= amount; 
                Dice.bonus(die, "x" + amount);
                break;
            }
            case (Operator.Rerolls): PlayerData.rolls += amount; break;
            case (Operator.Money): PlayerData.money += amount; break;
            default: break;
        }
    }
}

public enum Operator {
    Points, Multipier, Rerolls, Money
}

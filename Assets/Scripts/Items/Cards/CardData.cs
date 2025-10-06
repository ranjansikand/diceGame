// Card that can be collected
// Impacts scoring


using System.Collections;
using UnityEngine;


[CreateAssetMenu(fileName = "New Card", menuName = "Items/Card", order = 1)]
public class CardData : Item
{
    public override Type type { get { return Type.Card; }}
    [TextArea] public string Description;

    public virtual IEnumerator Check(Card card) {
        yield return null;
    }
}

public enum Operator {
    Points, Multipier, Rerolls, Money
}

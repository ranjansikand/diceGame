// Card that can be collected
// Impacts scoring


using System.Collections;
using UnityEngine;


[CreateAssetMenu(fileName = "New Card", menuName = "Items/Card", order = 1)]
public class CardData : Item
{
    [TextArea] public string Description;

    public virtual IEnumerator Check() {
        yield return null;
    }
}

public enum Operator {
    Points, Multipier, Rerolls, Money
}

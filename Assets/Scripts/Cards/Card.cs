// Card that can be collected
// Impacts scoring


using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards", order = 1)]
public class Card : ScriptableObject
{
    public string Name;
    [TextArea] public string Description;

    public virtual IEnumerator Check() {
        yield return null;
    }
}

public enum Operator {
    Points, Multipier, Rerolls, Money
}

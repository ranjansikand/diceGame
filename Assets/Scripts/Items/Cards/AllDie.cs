// Checks all die against a specific condition


using System.Collections;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class AllDie : CardData
{
    [SerializeField] protected Operator op;
    [SerializeField] protected int amount;
    [SerializeField, Range(1, 6)] protected int[] conditions;

    public override IEnumerator Check(Card card) {
        foreach (Dice die in Player.dice) {
            if (conditions.Contains(die.value)) {
                card.transform.DOScale(Vector3.one * 1.25f, 0.25f);
                yield return Data.quarterSecond;
            } else yield break;
        }
    }
}

// Visual representative of Card in UI


using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Card : MonoBehaviour
{
    CardDisplay cardDisplay;
    CardData card;

    public void Create(CardData card, CardDisplay cardDisplay) {
        this.card = card;
        this.cardDisplay = cardDisplay;
    }

    public IEnumerator Check() {
        transform.DOScale(Vector3.one * 1.05f, 0.05f);
        yield return card.Check(this);  
        transform.DOScale(Vector3.one, 0.1f);
    }
}

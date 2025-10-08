// Visual representative of Card in UI


using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Card : MonoBehaviour
{
    CardDisplay cardDisplay;
    CardData card;

    [SerializeField] TMP_Text cardName;

    public void Create(CardData card, CardDisplay cardDisplay) {
        this.card = card;
        this.cardDisplay = cardDisplay;

        cardName.text = card.Name;
    }

    public IEnumerator Check() {
        transform.DOScale(Vector3.one * 1.05f, 0.05f);
        yield return card.Check(this);  
        transform.DOScale(Vector3.one, 0.1f);
    }
}

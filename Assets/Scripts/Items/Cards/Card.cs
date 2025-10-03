// 


using System.Collections;
using UnityEngine;

public class Card : MonoBehaviour
{
    CardDisplay cardDisplay;
    CardData card;

    public void Create(CardData card, CardDisplay cardDisplay) {
        this.card = card;
        this.cardDisplay = cardDisplay;
    }

    public IEnumerator Check() {
        yield return card.Check();
    }
}

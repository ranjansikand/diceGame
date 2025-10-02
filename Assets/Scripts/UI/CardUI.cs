// 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUI : MonoBehaviour
{
    CardDisplay cardDisplay;
    Card card;

    public void Create(Card card, CardDisplay cardDisplay) {
        this.card = card;
        this.cardDisplay = cardDisplay;
    }
}

// Visual representative of Card in UI


using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using DG.Tweening;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    CardDisplay cardDisplay;
    CardData cardData;

    [SerializeField] TMP_Text cardName;

    public void Create(CardData card, CardDisplay cardDisplay) {
        this.cardData = card;
        this.cardDisplay = cardDisplay;

        cardName.text = card.Name;
    }

    public IEnumerator Check() {
        transform.DOScale(Vector3.one * 1.05f, 0.05f);
        yield return cardData.Check(this);  
        transform.DOScale(Vector3.one, 0.1f);
    }

    public void OnPointerEnter(PointerEventData data) {
        if (PlayerData.dragging) return;
        
        transform.DOScale(Vector3.one * 1.1f, 0.125f);
        Tooltip.instance.Show(cardData.Name, cardData.Description, data.position);
    }

    public void OnPointerExit(PointerEventData data) {
        transform.DOScale(Vector3.one, 0.125f);
        Tooltip.instance.Hide();
    }
}

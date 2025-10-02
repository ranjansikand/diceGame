// Displays cards on the UI


using System.Collections.Generic;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] CardUI cardPrefab;

    List<CardUI> displayedCards = new List<CardUI>();

    private void OnEnable() {
        Inventory.cardsUpdated += UpdateCards;
    }

    private void Start() {
        UpdateCards(0);
    }

    private void OnDisable() {
        Inventory.cardsUpdated -= UpdateCards;
    }

    private void UpdateCards(int index = 0) {
        if (displayedCards.Count == 0 && PlayerData.cards.Count > 0) {
            // Draw all the cards
            foreach (Card card in PlayerData.cards) {
                CardUI newCard = Instantiate(cardPrefab, transform);
                newCard.Create(card, this);
                displayedCards.Add(newCard);
            }
        } else if (displayedCards.Count > PlayerData.cards.Count) {
            // Remove card at index
            Destroy(displayedCards[index]);
            displayedCards.RemoveAt(index);
        } else if (displayedCards.Count < PlayerData.cards.Count) {
            CardUI newCard = Instantiate(cardPrefab, transform);
            newCard.Create(PlayerData.cards[index], this);
            displayedCards.Add(newCard);
        }
    }
}

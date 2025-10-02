// Adds and removes things from the player's inventory


public static class Inventory
{
    public delegate void InventoryUpdate(int i);
    public static InventoryUpdate cardsUpdated;

    public static void AddCard(Card card) {
        PlayerData.cards.Add(card);
        int index = PlayerData.cards.Count - 1;

        if (cardsUpdated != null) cardsUpdated(index);
    }

    public static void RemoveCard(Card card) {
        int index = PlayerData.cards.IndexOf(card);
        PlayerData.cards.RemoveAt(index);

        if (cardsUpdated != null) cardsUpdated(index);
    }

    public static void AddDice(Dice dice) {
        Dice newDice = Dice.Instantiate(dice);
        PlayerData.dice.Add(newDice);
    }

    public static void RemoveDice(Dice dice) {
        int index = PlayerData.dice.IndexOf(dice);
        Dice.Destroy(PlayerData.dice[index]);
        PlayerData.dice.RemoveAt(index);
    }
}

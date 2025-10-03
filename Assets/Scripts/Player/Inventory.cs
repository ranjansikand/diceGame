// Adds and removes things from the player's inventory


public static class Inventory
{
    public delegate void InventoryUpdate(int i);
    public static InventoryUpdate cardsUpdated, diceUpdated;

    public static void AddCard(CardData card) {
        PlayerData.cards.Add(card);

        if (cardsUpdated != null) cardsUpdated(PlayerData.cards.Count - 1);
    }

    public static void RemoveCard(CardData card) {
        int index = PlayerData.cards.IndexOf(card);
        PlayerData.cards.RemoveAt(index);

        if (cardsUpdated != null) cardsUpdated(index);
    }

    public static void AddDice(DiceData dice) {
        PlayerData.dice.Add(dice);

        if (diceUpdated != null) diceUpdated(PlayerData.dice.Count - 1);
    }

    public static void RemoveDice(DiceData dice) {
        int index = PlayerData.dice.IndexOf(dice);

        // Destroy the actual dice
        Dice.Destroy(Player.dice[index]);

        // Remove from both lists
        PlayerData.dice.RemoveAt(index);
        Player.dice.RemoveAt(index);
    }
}

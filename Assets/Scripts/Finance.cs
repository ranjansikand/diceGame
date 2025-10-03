// Calculates player salary and shop prices


public class Finance {
    public static void PayPlayer() {
        int interest = PlayerData.money / 5;
        PlayerData.money += (PlayerData.salary + interest + PlayerData.rolls);
    }

    public static int PriceItem(Item item, int rarity) {
        int price = 3;  // Base price

        price += price * rarity;  // Adjust for rarity

        if (item.GetType() == typeof(Dice))
            price += 2;  // Premium for a dice
        
        return price;
    }
}

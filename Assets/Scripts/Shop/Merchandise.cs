// An entry at the shop


using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Merchandise : MonoBehaviour
{
    Item item;
    int price;

    [SerializeField] TMP_Text priceTag, label;
    [SerializeField] Image border;
    [SerializeField] Color[] rarityColors;

    public void MarkForSale(Item item, int price, int rarity) {
        this.item = item;
        this.price = price;

        priceTag.text = price.ToString();
        label.text = item.Name;
        border.color = rarityColors[rarity];
    }

    public void Purchase() {
        if (PlayerData.money >= price) {
            PlayerData.money -= price;
            Inventory.AddItem(item);

            Debug.Log("Purchasing " + item);

            EmptyItem();
        }
    }

    private void EmptyItem() {
        priceTag.text = label.text = "";
        item = null;
        price = 100000;
    }
}

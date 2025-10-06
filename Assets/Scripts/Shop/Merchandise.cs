// An entry at the shop


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Merchandise : MonoBehaviour
{
    Item item;
    int price;

    [SerializeField] TMP_Text priceTag, label;

    public void MarkForSale(Item item, int price) {
        this.item = item;
        this.price = price;

        priceTag.text = price.ToString();
        label.text = item.Name;
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

// Shop that populates


using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] List<ShopItems> shopItems;
    [SerializeField] Merchandise merchandisePrefab;
    [SerializeField] GameObject shopCanvas;

    List<Merchandise> merch = new List<Merchandise>();

    private void OnEnable() {
        PopulateShop();
    }

    private void OnDisable() {
        for (int i = 0; i < merch.Count; i++) {
            Destroy(merch[i].gameObject);
        }

        merch.Clear();
    }

    private void PopulateShop() {
        for (int i = 0; i < 6; i++) {  // Add 4 items to shop
            int index = PickIndex();
            Item item = shopItems[index].items[Random.Range(0, shopItems[index].items.Count)];
            int price = Finance.PriceItem(item, index);

            Merchandise newMerch = Instantiate(merchandisePrefab, transform);
            newMerch.MarkForSale(item, price, index);
            merch.Add(newMerch);
        }
    }


    public static int PickIndex() {
        float rand = Random.Range(0f, 1f);

        if (rand <= 0.6f) {  // 60% common
            return 0;
        } else if (rand <= 0.9f) {  // 30% uncommon
            return 1;
        } else {  // 10% rare
            return 2;
        }
    }

    public void CloseShop() {  // Button
        SFX.playClick();
        shopCanvas.SetActive(false);
    }
}

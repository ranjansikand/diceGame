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
            int index = PickIndex(shopItems.Count);
            Item item = shopItems[index].items[Random.Range(0, shopItems[index].items.Count)];
            int price = Finance.PriceItem(item, index);

            Merchandise newMerch = Instantiate(merchandisePrefab, transform);
            newMerch.MarkForSale(item, price, index);
            merch.Add(newMerch);
        }
    }


    public static int PickIndex(int count) {
        if (count <= 0) return -1; // no items
        if (count == 1) return 0;  // only one item

        float rand = Random.value; // random 0..1
        float cumulative = 0f;

        for (int i = 0; i < count; i++) {
            // Probability is halved each step
            float probability = 1f / Mathf.Pow(2, i + 1);

            // For the last item, scoop up any remainder
            if (i == count - 1)
                probability = 1f - cumulative;

            cumulative += probability;

            if (rand < cumulative)
                return i;
        }

        return count - 1; // fallback (should never hit)
    }

    public void CloseShop() {  // Button
        SFX.playClick();
        shopCanvas.SetActive(false);
    }
}

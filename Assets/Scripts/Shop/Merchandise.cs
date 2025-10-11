// An entry at the shop


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;

public class Merchandise : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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

        OnPointerExit(null);
    }

    public void OnPointerEnter(PointerEventData data) {
        if (PlayerData.dragging || item == null) return;

        SFX.playHover();
        transform.DOScale(Vector3.one * 1.1f, 0.125f);
        Tooltip.instance.Show(item.Name, item.Description, data.position);
    }

    public void OnPointerExit(PointerEventData data) {
        transform.DOScale(Vector3.one, 0.125f);
        Tooltip.instance.Hide();
    }
}

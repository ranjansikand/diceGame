// Visualizes financial figures


using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] TMP_Text money, change;

    int displayedValue = 0;

    private void OnEnable() {
        PlayerData.moneyUpdated += MoneyUpdated;
        UpdateMoney();
    }

    private void OnDisable() {
        PlayerData.moneyUpdated -= MoneyUpdated;
    }

    private void MoneyUpdated() {
        int amount = PlayerData.money - displayedValue;

        string text = amount > 0 ? "+ " : "- ";
        text += "$" + amount;

        change.gameObject.SetActive(true);
        change.text = text;

        Invoke(nameof(UpdateMoney), 0.75f);
    }

    private void UpdateMoney() {
        change.gameObject.SetActive(false);
        money.text = "$" + PlayerData.money;
        displayedValue = PlayerData.money;
    }
}

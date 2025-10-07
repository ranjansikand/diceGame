// Displays the value of a dice


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DieCounters : MonoBehaviour
{
    [SerializeField] TMP_Text dieValuePrefab;

    List<TMP_Text> dieValueTrackers = new List<TMP_Text>();

    private void OnEnable() {
        Dice.rolled += Rolled;
        Dice.valueCalculated += AddValueTracker;
        Dice.bonus += Bonus;
    }

    private void OnDisable() {
        Dice.rolled -= Rolled;
        Dice.valueCalculated -= AddValueTracker;
        Dice.bonus -= Bonus;
    }

    private void Rolled(Dice dice) {
        if (dieValueTrackers.Count > 0) {
            foreach (TMP_Text tracker in dieValueTrackers) {
                tracker.gameObject.SetActive(false);
            }
        }
    }

    private void AddValueTracker(Dice dice) {
        TMP_Text tracker = GetTracker();
        tracker.transform.position = Camera.main.WorldToScreenPoint(dice.transform.position);
        tracker.text = dice.value.ToString();

        StartCoroutine(DeactivateTracker(tracker));
    }

    private void Bonus(Dice die, string message) {
        TMP_Text tracker = GetTracker();
        tracker.transform.position = Camera.main.WorldToScreenPoint(die.transform.position + Vector3.up);
        tracker.text = message;

        StartCoroutine(DeactivateTracker(tracker));
    }

    private IEnumerator DeactivateTracker(TMP_Text tracker) {
        yield return Data.halfSecond;
        tracker.gameObject.SetActive(false);
    }
    
    
    // Object Pool
    public TMP_Text GetTracker() {
        for (int i = 0; i < dieValueTrackers.Count; i++) {
            if (!dieValueTrackers[i].gameObject.activeSelf) {
                dieValueTrackers[i].gameObject.SetActive(true);
                return dieValueTrackers[i];
            }
        }

        TMP_Text newTracker = Instantiate(dieValuePrefab, transform);
        dieValueTrackers.Add(newTracker);
        return newTracker;
    }
}

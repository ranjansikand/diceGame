// Displays the value of a dice


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
    }

    private void OnDisable() {
        Dice.rolled -= Rolled;
        Dice.valueCalculated -= AddValueTracker;
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

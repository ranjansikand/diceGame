// Displays the value of a dice


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieCounters : MonoBehaviour
{
    [SerializeField] Counter dieValuePrefab;

    List<Counter> dieValueTrackers = new List<Counter>();

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
            foreach (Counter tracker in dieValueTrackers) {
                tracker.gameObject.SetActive(false);
            }
        }
    }

    private void AddValueTracker(Dice dice) {
        Counter tracker = GetTracker();
        tracker.transform.position = Camera.main.WorldToScreenPoint(dice.transform.position + Vector3.up);
        tracker.trackerText.text = dice.value.ToString();

        StartCoroutine(DeactivateTracker(tracker));
    }

    private void Bonus(Dice die, string message) {
        Counter tracker = GetTracker();
        tracker.transform.position = Camera.main.WorldToScreenPoint(die.transform.position + Vector3.down);
        tracker.trackerText.text = message;

        StartCoroutine(DeactivateTracker(tracker));
    }

    private IEnumerator DeactivateTracker(Counter tracker) {
        yield return Data.halfSecond;
        tracker.gameObject.SetActive(false);
    }
    
    
    // Object Pool
    public Counter GetTracker() {
        for (int i = 0; i < dieValueTrackers.Count; i++) {
            if (!dieValueTrackers[i].gameObject.activeSelf) {
                dieValueTrackers[i].gameObject.SetActive(true);
                return dieValueTrackers[i];
            }
        }

        Counter newTracker = Instantiate(dieValuePrefab, transform);
        dieValueTrackers.Add(newTracker);
        return newTracker;
    }
}

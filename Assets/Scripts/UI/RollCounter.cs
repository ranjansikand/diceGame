// Keeps track of the number of rolls


using UnityEngine;
using TMPro;

public class RollCounter : MonoBehaviour
{
    [SerializeField] TMP_Text rollCounter;

    private void OnEnable() {
        PlayerData.rollsUpdated += UpdateCounter;
        PlayerData.maxRollsUpdated += UpdateCounter;
    }

    private void Start() {
        UpdateCounter();
    }

    private void OnDisable() {
        PlayerData.rollsUpdated -= UpdateCounter;
        PlayerData.maxRollsUpdated -= UpdateCounter;
    }

    private void UpdateCounter() {
        rollCounter.text = PlayerData.rolls + " / " + PlayerData.maxRolls;
    }
}

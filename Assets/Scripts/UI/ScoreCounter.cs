// Keeps track of the player's score


using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TMP_Text scoreCounter;

    private void OnEnable() {
        PlayerData.scoreUpdated += UpdateCounter;

        UpdateCounter(0);
    }

    private void OnDisable() {
        PlayerData.scoreUpdated -= UpdateCounter;
    }

    private void UpdateCounter(int change) {
        scoreCounter.text = PlayerData.score.ToString();
    }
}

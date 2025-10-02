// Keeps track of the player's score


using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TMP_Text scoreCounter;

    private void OnEnable() {
        PlayerData.scoreUpdated += UpdateCounter;
    }

    private void Start() {
        UpdateCounter();
    }

    private void OnDisable() {
        PlayerData.scoreUpdated -= UpdateCounter;
    }

    private void UpdateCounter() {
        scoreCounter.text = PlayerData.score == 0 ? "" : PlayerData.score.ToString();
    }
}

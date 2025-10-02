// Keeps track of the round goal score


using UnityEngine;
using TMPro;

public class GoalTracker : MonoBehaviour
{
    [SerializeField] TMP_Text scoreCounter;

    private void OnEnable() {
        GameManager.scoreUpdated += UpdateCounter;
    }

    private void OnDisable() {
        GameManager.scoreUpdated -= UpdateCounter;
    }

    private void UpdateCounter() {
        scoreCounter.text = GameManager.roundScore.ToString();
    }
}

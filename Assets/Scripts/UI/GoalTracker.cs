// Keeps track of the round goal score


using UnityEngine;
using TMPro;
using DG.Tweening;

public class GoalTracker : MonoBehaviour
{
    [SerializeField] TMP_Text scoreCounter;

    private void OnEnable() {
        GameManager.scoreUpdated += UpdateCounter;

        // Update the text
        scoreCounter.text = GameManager.roundScore.ToString();
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one * 1.25f, 0.25f).OnComplete(
            () => transform.DOScale(Vector3.one, 0.5f)
        );
    }

    private void OnDisable() {
        GameManager.scoreUpdated -= UpdateCounter;
    }

    private void UpdateCounter() {
        transform.DOScale(Vector3.one * 1.25f, 0.125f).OnComplete(() => {
            scoreCounter.text = GameManager.roundScore.ToString();
            transform.DOScale(Vector3.one, 0.25f);
        });
    }
}

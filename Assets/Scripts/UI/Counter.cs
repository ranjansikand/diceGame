// Pop in


using UnityEngine;
using DG.Tweening;
using TMPro;

public class Counter : MonoBehaviour
{
    public TMP_Text trackerText;

    private void OnEnable() {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one * 1.25f, 0.125f).OnComplete(
            () => transform.DOScale(Vector3.one, 0.25f)
        );
    }

    private void OnDisable() {
        transform.localScale = Vector3.zero;
    }
}

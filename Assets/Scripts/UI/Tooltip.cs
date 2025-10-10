// Tooltip


using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Tooltip : MonoBehaviour
{
    public static Tooltip instance;
    Coroutine tooltipRoutine;

    [SerializeField] GameObject tooltip;
    [SerializeField] RectTransform tt;
    [SerializeField] TMP_Text title, description;

    [SerializeField] float offset;

    private void OnEnable() {
        if (instance != null) {
            Destroy(instance.gameObject);    
        }
        
        instance = this;
    }

    private void OnDisable() {
        instance = null;
    }

    public void Show(string title, string description, Vector3 pos, bool worldPoint = true) {
        tooltipRoutine = StartCoroutine(TooltipRoutine(title,  description,  pos,  worldPoint));
    }

    public void Hide() {
        StopCoroutine(tooltipRoutine);
        tooltip.transform.DOScale(Vector3.zero, 0.125f).OnComplete(
            () => tooltip.SetActive(false)
        );
    }

    IEnumerator TooltipRoutine(string title, string description, Vector3 pos, bool worldPoint = true) {
        yield return Data.halfSecond;
        ShowTooltip( title,  description,  pos,  worldPoint);
    }

    private void ShowTooltip(string title, string description, Vector3 pos, bool worldPoint = true) {
        // Turn it on
        tooltip.SetActive(true);
        tooltip.transform.position = ClampToScreen(pos, offset);

        // Pop in
        tooltip.transform.localScale = Vector3.zero;
        tooltip.transform.DOScale(Vector3.one * 1.25f, 0.25f).OnComplete(
            () => tooltip.transform.DOScale(Vector3.one, 0.125f)
        );

        this.title.text = title;
        this.description.text = description;
    }

    public static Vector3 ClampToScreen(Vector3 pos, float offset = 0f) {
        // Rect parameters
        float width = 144/2;
        float height = 80/2;

        return new Vector3(
            Mathf.Clamp(pos.x, 0 + width, Screen.width - width),
            Mathf.Clamp(pos.y - height - 4, 0 + height, Screen.height),
            0
        );
    }
}

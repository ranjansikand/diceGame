// Stick it to a button


using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Button : MonoBehaviour, 
    IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerClick(PointerEventData data) {
        SFX.playClick();
    }

    public void OnPointerEnter(PointerEventData data) {
        if (PlayerData.dragging) return;
        
        SFX.playHover();
        transform.DOScale(Vector3.one * 1.1f, 0.125f);
    }

    public void OnPointerExit(PointerEventData data) {
        transform.DOScale(Vector3.one, 0.125f);
    }
}

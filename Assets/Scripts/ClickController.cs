using UnityEngine;
using UnityEngine.EventSystems;

public class ClickController : MonoBehaviour, IPointerClickHandler
{
    public TileController controller;

    public void OnPointerClick(PointerEventData eventData) 
    {
        controller.move(eventData.pointerCurrentRaycast.gameObject.name);
    }
}

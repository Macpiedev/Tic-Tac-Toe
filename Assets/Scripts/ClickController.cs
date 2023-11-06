using UnityEngine;
using UnityEngine.EventSystems;

public class ClickController : MonoBehaviour, IPointerClickHandler
{
    public GameManager gameManager;

    public void OnPointerClick(PointerEventData eventData) 
    {
        if(gameManager.isPlayerMove) {
            string tileName = eventData.pointerCurrentRaycast.gameObject.name;
            int tileId = tileName[tileName.Length-1] - '0';
            gameManager.playerMove(tileId - 1);
        }
    }
}

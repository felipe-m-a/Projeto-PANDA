using UnityEngine;
using UnityEngine.EventSystems;

namespace Panda.Minigames.Flow
{
    public class BoardInputReader : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler,
        IPointerMoveHandler
    {
        public bool isTracing;

        public void OnPointerDown(PointerEventData eventData)
        {
            isTracing = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isTracing = false;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            isTracing = false;
        }

        public void OnPointerMove(PointerEventData eventData)
        {
        }
    }
}
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler,
    IEndDragHandler
{
    public static GameObject ItemBeingDragged;
    [SerializeField] private CanvasGroup _canvasGroup;
    
    [Header("Drag Event Responses")]
    [Space]
    [SerializeField] private UnityEvent OnBeginDragResponse;

    private Vector3 _startPosition;
    
    #region IBeginDragHandler, IDragHandler, IEndDragHandler Methods
    public void OnBeginDrag(PointerEventData eventData)
    {
        ItemBeingDragged = gameObject;
        _startPosition = transform.position;
        OnBeginDragResponse?.Invoke();
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ItemBeingDragged = null;
        transform.position = _startPosition;
        _canvasGroup.blocksRaycasts = true;
    }
    #endregion
}

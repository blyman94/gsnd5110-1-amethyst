using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    [SerializeField] private StoryDataBinding _storyDataBinding;
    [SerializeField] private PostDisplay _postDisplay;
    [SerializeField] private UnityEvent _onDropResponse;
    
    #region IDropHandler Methods
    public void OnDrop(PointerEventData eventData)
    {
        _storyDataBinding.StoryData = DragHandler.ItemBeingDragged
            .GetComponent<StoryDataBinding>().StoryData;
        _postDisplay.ShowStoryDisplayTransforms();
        _onDropResponse?.Invoke();
    }
    #endregion
}

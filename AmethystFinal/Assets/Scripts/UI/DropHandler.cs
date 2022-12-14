using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    [SerializeField] private StoryDataBinding _storyDataBinding;
    [SerializeField] private PostDisplay _postDisplay;
    [SerializeField] private UnityEvent _onDropResponse;
    [SerializeField] private UnityEvent _onStorySpunResponse;
    
    #region IDropHandler Methods
    public void OnDrop(PointerEventData eventData)
    {
        var droppedStoryData = DragHandler.ItemBeingDragged
            .GetComponent<StoryDataBinding>().StoryData;
        _storyDataBinding.StoryData = droppedStoryData;
        _postDisplay.ShowStoryDisplayTransforms();
        _onDropResponse?.Invoke();
        if (droppedStoryData.SpinStory)
        {
            _onStorySpunResponse?.Invoke();
        }
    }
    #endregion
}

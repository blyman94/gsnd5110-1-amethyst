using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class RemainingStoryChecker : MonoBehaviour
{
    [SerializeField] private int _storiesPerDay = 2;
    [SerializeField] private IntVariable _dayCount;
    [SerializeField] private IntVariable _remainingStoryCount;
    [SerializeField] private UnityEvent _remainingStoriesResponse;
    [SerializeField] private UnityEvent _noRemainingStoriesResponse;

    #region MonoBehaviour Methods

    private void Start()
    {
        ResetRemainingStoryCount();
    }
    #endregion

    public void ResetRemainingStoryCount()
    {
        _remainingStoryCount.Value = _storiesPerDay;
    }

    public void CheckRemainingStories()
    {
        if (_remainingStoryCount.Value > 0)
        {
            _remainingStoriesResponse?.Invoke();
        }
        else
        {
            _noRemainingStoriesResponse?.Invoke();
        }
    }
}

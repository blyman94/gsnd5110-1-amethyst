using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class StoryLoader : MonoBehaviour
{
    [SerializeField] private GameObject _availableStoryDisplayPrefab;
    [SerializeField] private StoryDataVariable _activeStory;
    [SerializeField] private PostDecisionVariable _postDecision;
    [SerializeField] private IntVariable _dayCounter;
    [SerializeField] private StoryData[] _startingStories;
    [SerializeField] private Transform _availableStoryParent;
    [SerializeField] private UnityEvent _newStoriesResponse;
    [SerializeField] private UnityEvent _noNewStoriesResponse;
    [SerializeField] private ListOfStringsVariable _resolutionStrings;

    private List<StoryData> _currentStories;
    private List<StoryData> _futureStories;
    private List<StoryData> _pastStories;
    
    
    #region MonoBehaviour Methods
    private void Awake()
    {
        _futureStories = new List<StoryData>();
        _currentStories = new List<StoryData>();
        _pastStories = new List<StoryData>();
    }

    private void Start()
    {
        _resolutionStrings.Value.Clear();
        _currentStories = _startingStories.ToList();
        _dayCounter.Value = 1;
        DisplayCurrentStories();
    }
    #endregion

    public void MoveToNextDay()
    {
        // Add results of no-posts to future stories
        foreach (StoryData storyData in _currentStories)
        {
            if (storyData.DoNotPostResult != null)
            {
                _futureStories.Add(storyData.DoNotPostResult);
            }
            else
            {
                var stringsUpdate = _resolutionStrings.Value;
                stringsUpdate.Add(storyData.ResolutionSummary);
                _resolutionStrings.Value = stringsUpdate;
            }
        }

        if (_futureStories.Count > 0)
        {
            // Move future stories to current stories
            _currentStories = new List<StoryData>(_futureStories);
        
            // Clear future stories
            _futureStories.Clear();
            
            _newStoriesResponse?.Invoke();
        }
        else
        {
            _noNewStoriesResponse?.Invoke();
        }
    }

    public void UpdateCurrentStories()
    {
        _pastStories.Add(_activeStory.Value);
        _currentStories.Remove(_activeStory.Value);
    }

    public void DisplayCurrentStories()
    {
        foreach (StoryData storyData in _currentStories)
        {
            if (storyData.AvailableStartingDay == _dayCounter.Value)
            {
                GameObject displayObject = Instantiate(_availableStoryDisplayPrefab,
                    _availableStoryParent);
                displayObject.GetComponent<StoryDataBinding>().StoryData =
                    storyData;
            }
        }
    }

    public void UpdateFutureStories()
    {
        bool isResolution = true;
        switch (_postDecision.Value)
        {
            case PostDecision.Anonymous:
                if (_activeStory.Value.AnonymousResult != null)
                {
                    _futureStories.Add(_activeStory.Value.AnonymousResult);
                    isResolution = false;
                }
                break;
            case PostDecision.Government:
                if (_activeStory.Value.GovernmentResult != null)
                {
                    _futureStories.Add(_activeStory.Value.GovernmentResult);
                    isResolution = false;
                }
                break;
            case PostDecision.DoNot:
                if (_activeStory.Value.DoNotPostResult != null)
                {
                    _futureStories.Add(_activeStory.Value.DoNotPostResult);
                    isResolution = false;
                }
                break;
            default:
                Debug.Log("Unknown PostDecision passed to " +
                          "StoryLoader.UpdateFutureStories()");
                break;
        }

        if (isResolution)
        {
            var stringsUpdate = _resolutionStrings.Value;
            stringsUpdate.Add(_activeStory.Value.ResolutionSummary);
            _resolutionStrings.Value = stringsUpdate;
        }
    }

    public void ResetAvailableStories()
    {
        for(int i = _availableStoryParent.childCount - 1; i >= 0; i--)
        {
            Destroy(_availableStoryParent.GetChild(i).gameObject);
        }
        DisplayCurrentStories();
    }
}

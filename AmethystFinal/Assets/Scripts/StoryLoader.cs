using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StoryLoader : MonoBehaviour
{
    [SerializeField] private GameObject _availableStoryDisplayPrefab;
    [SerializeField] private StoryDataVariable _activeStory;
    [SerializeField] private PostDecisionVariable _postDecision;
    [SerializeField] private StoryData[] _startingStories;
    [SerializeField] private Transform _availableStoryParent;

    private List<StoryData> _futureStories;
    
    #region MonoBehaviour Methods
    private void Awake()
    {
        _futureStories = new List<StoryData>();
    }

    private void Start()
    {
        foreach (StoryData storyData in _startingStories)
        {
            GameObject displayObject = Instantiate(_availableStoryDisplayPrefab,
                _availableStoryParent);
            displayObject.GetComponent<StoryDataBinding>().StoryData =
                storyData;
        }
    }
    #endregion

    public void UpdateFutureStories()
    {
        switch (_postDecision.Value)
        {
            case PostDecision.Anonymous:
                if (_activeStory.Value.AnonymousResult != null)
                {
                    _futureStories.Add(_activeStory.Value.AnonymousResult);
                }
                break;
            case PostDecision.Government:
                if (_activeStory.Value.GovernmentResult != null)
                {
                    _futureStories.Add(_activeStory.Value.GovernmentResult);
                }
                break;
            case PostDecision.DoNot:
                if (_activeStory.Value.DoNotPostResult != null)
                {
                    _futureStories.Add(_activeStory.Value.DoNotPostResult);
                }
                break;
            default:
                Debug.Log("Unknown PostDecision passed to " +
                          "StoryLoader.UpdateFutureStories()");
                break;
        }
    }
}

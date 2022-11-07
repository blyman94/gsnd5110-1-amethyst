using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for loading stories into the UI.
/// </summary>
public class StoryLoader : MonoBehaviour
{
    /// <summary>
    /// List of stories to be displayed on the feed.
    /// </summary>
    [SerializeField] private List<Story> _currentStories;

    /// <summary>
    /// Prefab of the StoryDisplay object.
    /// </summary>
    [SerializeField] private GameObject _storyDisplayPrefab;

    /// <summary>
    /// Transform who will act as the parent to each StoryDisplay created.
    /// </summary>
    [SerializeField] private Transform _storyParentTransform;

    /// <summary>
    /// IntVariable representing how many iterations have passed.
    /// </summary>
    [SerializeField] private IntVariable _iterationCount;

    /// <summary>
    /// All future stories.
    /// </summary>
    private List<Story> _futureStories;

    /// <summary>
    /// All past stories.
    /// </summary>
    private List<Story> _pastStories;

    #region MonoBehaviour Methods
    private void Awake()
    {
        _iterationCount.Value = 0;
        _futureStories = new List<Story>();
        _pastStories = new List<Story>();
        LoadCurrentStories();
    }
    private void OnDisable()
    {
        foreach (Story story in _pastStories)
        {
            story.PostDecision = PostDecision.DoNot;
        }
    }
    #endregion

    /// <summary>
    /// Progresses the storylines.
    /// </summary>
    public void MoveToNextIteration()
    {
        _iterationCount.Value++;

        // Store future stories
        foreach (Story story in _currentStories)
        {
            switch (story.PostDecision)
            {
                case (PostDecision.External):
                    if (story.PostedExternallyResult != null)
                    {
                        _futureStories.Add(story.PostedExternallyResult);
                    }
                    break;
                case (PostDecision.Internal):
                    if (story.PostedInternallyResult != null)
                    {
                        _futureStories.Add(story.PostedInternallyResult);
                    }
                    break;
                case (PostDecision.DoNot):
                    if (story.NotPostedResult != null)
                    {
                        _futureStories.Add(story.NotPostedResult);
                    }
                    break;
                default:
                    break;
            }

            _pastStories.Add(story);
        }

        // Update current stories list
        _currentStories.Clear();
        foreach (Story story in _futureStories)
        {
            Debug.Log(story.WhenToPost);
            if (story.WhenToPost == _iterationCount.Value)
            {
                _currentStories.Add(story);
            }
        }

        // Load new stories
        LoadCurrentStories();
    }

    /// <summary>
    /// Clears all story dispay objects.
    /// </summary>
    private void ClearStoryFeed()
    {
        if (_storyParentTransform.transform.childCount >= 1)
        {
            for (int i = _storyParentTransform.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(_storyParentTransform.transform.GetChild(i).gameObject);
            }
        }
    }

    /// <summary>
    /// Loads all stories in _storiesToLoad list.
    /// </summary>
    private void LoadCurrentStories()
    {
        ClearStoryFeed();
        foreach (Story story in _currentStories)
        {
            GameObject storyDisplayObject =
                Instantiate(_storyDisplayPrefab, _storyParentTransform);
            StoryDisplay storyDisplay =
                storyDisplayObject.GetComponent<StoryDisplay>();
            storyDisplay.StoryToDisplay = story;
        }
    }
}

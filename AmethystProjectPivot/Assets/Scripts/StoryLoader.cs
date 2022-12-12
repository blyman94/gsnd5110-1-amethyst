using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// Responsible for loading stories into the UI.
/// </summary>
public class StoryLoader : MonoBehaviour
{
    public CommentSequence CommentSequence;
    
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

    [SerializeField] private TextMeshProUGUI _faderText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private TextMeshProUGUI _totalCommentsText;
    [SerializeField] private TextMeshProUGUI _totalFollowersText;
    [SerializeField] private IntVariable _totalCommentCount;
    [SerializeField] private IntVariable _totalFollowerCount;
    [SerializeField] private ScreenFader _screenFader;
    

    /// <summary>
    /// IntVariable representing how many iterations have passed.
    /// </summary>
    [SerializeField] private IntVariable _iterationCount;

    [Header("Story Count Events")]
    [SerializeField] private UnityEvent _tooManyStoriesEvent;
    [SerializeField] private UnityEvent _notTooManyStoriesEvent;

    /// <summary>
    /// All future stories.
    /// </summary>
    private List<Story> _futureStories;

    /// <summary>
    /// All past stories.
    /// </summary>
    private List<Story> _pastStories;

    private int _postCount = 0;

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

    public void CountPostedStories()
    {
        _postCount = 0;
        foreach (Story story in _currentStories)
        {
            if (story.PostDecision == PostDecision.External ||
                story.PostDecision == PostDecision.Internal)
            {
                _postCount++;
            }
        }
        if (_postCount > 1)
        {
            _tooManyStoriesEvent?.Invoke();
        }
        else
        {
            _notTooManyStoriesEvent?.Invoke();
        }
    }

    /// <summary>
    /// Progresses the storylines.
    /// </summary>
    public void MoveToNextIteration()
    {
        _futureStories.Clear();
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

        _iterationCount.Value++;

        CommentSequence.StartCommentSequence(_currentStories);

        // Update current stories list
        _currentStories.Clear();
        foreach (Story story in _futureStories)
        {
            if (story.WhenToPost == _iterationCount.Value)
            {
                _currentStories.Add(story);
            }
        }

        // Load new stories
        LoadCurrentStories();
    }

    public void CheckFutureStories()
    {
        if (_futureStories.Count <= 0)
        {
            _faderText.text = "Game Over! \n All storylines have resolved.";
            
            _totalCommentsText.transform.parent.gameObject.SetActive(true);
            _totalFollowersText.transform.parent.gameObject.SetActive(true);
            _totalCommentsText.text = _totalCommentCount.Value.ToString();
            _totalFollowersText.text = _totalFollowerCount.Value.ToString();
            
            _restartButton.gameObject.SetActive(true);
            _screenFader.GetComponent<CanvasGroup>().alpha = 1;
            _screenFader.GetComponent<CanvasGroup>().blocksRaycasts = true;
            _screenFader.GetComponent<CanvasGroup>().interactable = true;
            _screenFader.StopFade();
            return;
        }
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
        CountPostedStories();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class CommentSequence : MonoBehaviour
{
    [Header("Data References")]
    [SerializeField] private StoryDisplay _storyDisplay;
    [SerializeField] private TextMeshProUGUI[] _commentTexts;
    
    [Header("UI Animator References")]
    [SerializeField] private Animator _storyDisplayAnimator;
    [SerializeField] private Animator[] _commentDisplayAnimators;
    [SerializeField] private Animator[] _metricDisplayAnimators;
    
    [Header("Timing")]
    [SerializeField] private float _startDelay = 0.0f;
    [SerializeField] private float _timeBetweenStoryAndFirstComment = 1.0f;
    [SerializeField] private float _timeBetweenComments = 0.5f;
    [SerializeField] private float _timeBetweenCommentsAndMetrics = 1.0f;
    [SerializeField] private float _timeBetweenMetrics = 0.1f;
    [SerializeField] private float _timeBetweenMetricsAndButton = 0.5f;

    [Header("Buttons")] 
    [SerializeField] private GameObject _nextButtonObject;
    [SerializeField] private GameObject _doneButtonObject;
    [SerializeField] private Story _nullStory;

    [Header("Metrics")] 
    [SerializeField] private int _startingCommentCount = 0;
    [SerializeField] private int _startingFollowerCount = 0;
    [SerializeField] private IntVariable _totalCommentCount;
    [SerializeField] private IntVariable _totalFollowerCount;

    [Header("Metric Display Texts")] 
    [SerializeField] private TextMeshProUGUI _commentTotalBeforeText;
    [SerializeField] private TextMeshProUGUI _newCommentsText;
    [SerializeField] private TextMeshProUGUI _newCommentTotalText;
    [SerializeField] private TextMeshProUGUI _followerTotalBeforeText;
    [SerializeField] private TextMeshProUGUI _newFollowersText;
    [SerializeField] private TextMeshProUGUI _newFollowerTotalText;

    private List<Story> _postedStoriesToShow;
    private int _currentCommentCount;

    private void Start()
    {
        _totalCommentCount.Value = _startingCommentCount;
        _totalFollowerCount.Value = _startingFollowerCount;
    }

    public List<Story> StoriesToShow
    {
        set
        {
            _postedStoriesToShow = value
                .Where(x => x.PostDecision != PostDecision.DoNot).ToList();
        }
    }
    private int CurrentStoryIndex { get; set; } = 0;
    
    public void StartCommentSequence(List<Story> storiesToShow)
    {
        CurrentStoryIndex = 0;
        StoriesToShow = storiesToShow;
        ShowStory();
    }

    private void ShowStory()
    {
        ResetCommentsAndMetrics();
        Story currentStory;
        _currentCommentCount = 0;

        // Update story display
        if (_postedStoriesToShow.Count > 0)
        {
            currentStory = _postedStoriesToShow[CurrentStoryIndex];
        }
        else
        {
            currentStory = _nullStory;
        }
       
        _storyDisplay.StoryToDisplay = currentStory;
        
        // External Decision
        if (currentStory.PostDecision == PostDecision.External &&
            currentStory.PostedExternallyComments.Length > 0)
        {
            // Update comment strings
            _currentCommentCount = currentStory.PostedExternallyComments.Length;
            for (int i = 0; i < currentStory.PostedExternallyComments.Length; i++)
            {
                _commentTexts[i].text =
                    currentStory.PostedExternallyComments[i];
            }
            
            // Update Followers
            _followerTotalBeforeText.text = _totalFollowerCount.Value.ToString();
            _newFollowersText.text = currentStory.PostedExternallyFollowerDelta.ToString();
            int newFollowerCount = _totalFollowerCount.Value +
                                  currentStory.PostedExternallyFollowerDelta;
            _newFollowerTotalText.text = newFollowerCount.ToString();
            _totalFollowerCount.Value = newFollowerCount;
        }
        else if (currentStory.PostDecision == PostDecision.Internal &&
            currentStory.PostedInternallyComments.Length > 0)
        {
            for (int i = 0; i < currentStory.PostedInternallyComments.Length; i++)
            {
                _currentCommentCount = currentStory.PostedInternallyComments.Length;
                _commentTexts[i].text =
                    currentStory.PostedInternallyComments[i];
            }
            
            // Update Followers
            _followerTotalBeforeText.text = _totalFollowerCount.Value.ToString();
            _newFollowersText.text = currentStory.PostedInternallyFollowerDelta.ToString();
            int newFollowerCount = _totalFollowerCount.Value +
                                   currentStory.PostedInternallyFollowerDelta;
            _newFollowerTotalText.text = newFollowerCount.ToString();
            _totalFollowerCount.Value = newFollowerCount;
        }
        else
        {
            _followerTotalBeforeText.text = _totalFollowerCount.Value.ToString();
            _newFollowersText.text = "0";
            _newFollowerTotalText.text = _totalFollowerCount.Value.ToString();
        }
        
        // Update Comments
        _commentTotalBeforeText.text = _totalCommentCount.Value.ToString();
        _newCommentsText.text = _currentCommentCount.ToString();
        int newCommentCount = _totalCommentCount.Value + 
                              _currentCommentCount;
        _newCommentTotalText.text = newCommentCount.ToString();
        _totalCommentCount.Value = newCommentCount;
        
        // Play entrance routine
        StartCoroutine(EntranceRoutine());
    }

    private void ShowButton()
    {
        CurrentStoryIndex++;
        if (CurrentStoryIndex < _postedStoriesToShow.Count)
        {
            _nextButtonObject.SetActive(true);
        }
        else
        {
            _doneButtonObject.SetActive(true);
        }
    }

    private IEnumerator EntranceRoutine()
    {
        yield return new WaitForSeconds(_startDelay);
        _storyDisplayAnimator.Play("SlideInFromRight");
        yield return new WaitForSeconds(_timeBetweenStoryAndFirstComment);

        for (int i = 0; i < _currentCommentCount; i++)
        {
            _commentDisplayAnimators[i].Play("SlideInFromLeft");
            yield return new WaitForSeconds(_timeBetweenComments);
        }
        yield return new WaitForSeconds(_timeBetweenCommentsAndMetrics);
        
        foreach(Animator animator in _metricDisplayAnimators)
        {
            animator.Play("MetricFadeIn");
            yield return new WaitForSeconds(_timeBetweenMetrics);
        }
        yield return new WaitForSeconds(_timeBetweenMetricsAndButton);
        
        ShowButton();
    }

    private void ResetCommentsAndMetrics()
    {
        _doneButtonObject.SetActive(false);
        _nextButtonObject.SetActive(false);
        
        _storyDisplayAnimator.Play("Idle");
        for (int i = 0; i < _commentDisplayAnimators.Length; i++)
        {
            _commentDisplayAnimators[i].Play("Idle");
        }
        foreach(Animator animator in _metricDisplayAnimators)
        {
            animator.Play("Idle");
        }
    }
}

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
    
    [Header("Timing")]
    [SerializeField] private float _startDelay = 0.0f;
    [SerializeField] private float _timeBetweenStoryAndFirstComment = 1.0f;
    [SerializeField] private float _timeBetweenComments = 0.5f;

    [Header("Buttons")] 
    [SerializeField] private GameObject _nextButtonObject;
    [SerializeField] private GameObject _doneButtonObject;
    [SerializeField] private Story _nullStory;

    private List<Story> _postedStoriesToShow;
    private int _currentCommentCount;

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
        ResetComments();
        Story currentStory;
        
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
        
        // Update comment strings if applicable
        if (currentStory.PostDecision == PostDecision.External &&
            currentStory.PostedExternallyComments.Length > 0)
        {
            _currentCommentCount = currentStory.PostedExternallyComments.Length;
            for (int i = 0; i < currentStory.PostedExternallyComments.Length; i++)
            {
                _commentTexts[i].text =
                    currentStory.PostedExternallyComments[i];
            }
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
        }
        
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

        ShowButton();
    }

    private void ResetComments()
    {
        _doneButtonObject.SetActive(false);
        _nextButtonObject.SetActive(false);
        
        _storyDisplayAnimator.Play("Idle");
        for (int i = 0; i < _commentDisplayAnimators.Length; i++)
        {
            _commentDisplayAnimators[i].Play("Idle");
        }
    }
}

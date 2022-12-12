using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CommentAnimationHandler : MonoBehaviour
{
    public static int CurrentCommentCount = 0;
    public static bool ShowAnonymous = false;
    
    [SerializeField] private StoryDataVariable _currentStory;
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _isAnonymous;
    [Header("Events")]
    [SerializeField] private UnityEvent _OnSlideAnimationEndResponse;
    [SerializeField] private UnityEvent _OnCommentSequenceEndResponse;

    private int _idleStateHash;
    private int _slideLeftToRightStateHash;
    private int _slideRightToLeftStateHash;
    

    #region MonoBehaviour Methods
    private void Awake()
    {
        _idleStateHash = Animator.StringToHash("Idle");
        _slideLeftToRightStateHash = Animator.StringToHash("SlideLeftToRight");
        _slideRightToLeftStateHash = Animator.StringToHash("SlideRightToLeft");
    }

    private void Start()
    {
        PlayIdleAnimation();
    }
    #endregion

    public void OnSlideAnimationEnd()
    {
        if (CurrentCommentCount + 1 < (Mathf.Min(_currentStory.Value.TotalComments,4)))
        {
            _OnSlideAnimationEndResponse?.Invoke();
            CurrentCommentCount++;
        }
        else
        {
            _OnCommentSequenceEndResponse?.Invoke();
            CurrentCommentCount = 0;
        }
    }
    
    public void PlayIdleAnimation()
    {
        _animator.Play(_idleStateHash);
    }

    public void PlaySlideLeftToRightAnimation()
    {
        if (_isAnonymous && ShowAnonymous)
        {
            _animator.Play(_slideLeftToRightStateHash);
        }
    }
    
    public void PlaySlideRightToLeftAnimation()
    {
        if (!_isAnonymous && !ShowAnonymous)
        {
            _animator.Play(_slideRightToLeftStateHash);
        }
    }

    public void SetShowAnonymous(bool showAnonymous)
    {
        ShowAnonymous = showAnonymous;
    }
}

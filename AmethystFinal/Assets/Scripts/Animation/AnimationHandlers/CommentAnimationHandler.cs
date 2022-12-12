using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CommentAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private UnityEvent _OnSlideAnimationEndResponse;

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
        _OnSlideAnimationEndResponse?.Invoke();
    }
    
    public void PlayIdleAnimation()
    {
        _animator.Play(_idleStateHash);
    }

    public void PlaySlideLeftToRightAnimation()
    {
        _animator.Play(_slideLeftToRightStateHash);
    }
    
    public void PlayRightToLeftAnimation()
    {
        _animator.Play(_slideRightToLeftStateHash);
    }
}

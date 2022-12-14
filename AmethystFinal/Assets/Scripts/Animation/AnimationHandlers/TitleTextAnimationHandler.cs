using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TitleTextAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private UnityEvent _onAnimationEndResponse;
    
    private int _idleStateHash;
    private int _fadeInStateHash;
    private int _fadeOutStateHash;
    private int _slideStateHash;
    private int _stampStateHash;
    
    #region MonoBehaviour Methods
    private void Awake()
    {
        _idleStateHash = Animator.StringToHash("Idle");
        _fadeInStateHash = Animator.StringToHash("FadeIn");
        _fadeOutStateHash = Animator.StringToHash("FadeOut");
        _slideStateHash = Animator.StringToHash("SlideLeftToRight");
        _stampStateHash = Animator.StringToHash("Stamp");
    }

    private void Start()
    {
        PlayIdleAnimation();
    }
    #endregion
    
    public void OnAnimationEnd()
    {
        _onAnimationEndResponse?.Invoke();
    }

    public void PlayFadeInAnimation()
    {
        _animator.Play(_fadeInStateHash);
    }
    
    public void PlayFadeOutAnimation()
    {
        _animator.Play(_fadeOutStateHash);
    }
    
    public void PlayIdleAnimation()
    {
        _animator.Play(_idleStateHash);
    }
    
    public void PlaySlideAnimation()
    {
        _animator.Play(_slideStateHash);
    }

    public void PlayStampAnimation()
    {
        _animator.Play(_stampStateHash);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PostedTextAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private UnityEvent _onStampAnimationEndResponse;

    private int _idleStateHash;
    private int _stampStateHash;

    #region MonoBehaviour Methods
    private void Awake()
    {
        _idleStateHash = Animator.StringToHash("Idle");
        _stampStateHash = Animator.StringToHash("Stamp");
    }

    private void Start()
    {
        PlayIdleAnimation();
    }
    #endregion

    public void OnStampAnimationEnd()
    {
        _onStampAnimationEndResponse?.Invoke();
    }
    
    public void PlayIdleAnimation()
    {
        _animator.Play(_idleStateHash);
    }

    public void PlayStampAnimation()
    {
        _animator.Play(_stampStateHash);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCounterAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    private int _idleStateHash;
    private int _slideInAndOutStateHash;
    
    #region MonoBehaviour Methods
    private void Awake()
    {
        _idleStateHash = Animator.StringToHash("Idle");
        _slideInAndOutStateHash = Animator.StringToHash("SlideInAndOut");
    }
    #endregion
    
    public void PlayIdleAnimation()
    {
        _animator.Play(_idleStateHash);
    }
    
    public void PlaySlideInAndOutAnimation()
    {
        _animator.Play(_slideInAndOutStateHash);
    }
}

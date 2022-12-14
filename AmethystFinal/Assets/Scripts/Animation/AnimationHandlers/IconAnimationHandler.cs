using UnityEngine;
using UnityEngine.Events;

public class IconAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private UnityEvent _onAnimationEndResponse;
    
    private int _idleStateHash;
    private int _showAndSettleStateHash;
    
    #region MonoBehaviour Methods
    private void Awake()
    {
        _idleStateHash = Animator.StringToHash("Idle");
        _showAndSettleStateHash = Animator.StringToHash("ShowAndSettle");
    }
    #endregion
    
    public void OnAnimationEnd()
    {
        _onAnimationEndResponse?.Invoke();
    }
    
    public void PlayIdleAnimation()
    {
        _animator.Play(_idleStateHash);
    }
    
    public void PlayShowAndSettleAnimation()
    {
        _animator.Play(_showAndSettleStateHash);
    }
}

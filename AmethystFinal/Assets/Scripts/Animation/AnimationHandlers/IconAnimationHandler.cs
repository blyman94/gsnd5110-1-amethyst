using UnityEngine;
using UnityEngine.Events;

public class IconAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private UnityEvent _onShowAndSettleEndResponse;
    [SerializeField] private UnityEvent _onShowAndSettleReverseEndResponse;
    
    private int _idleStateHash;
    private int _showAndSettleStateHash;
    private int _showAndSettleReverseStateHash;
    
    #region MonoBehaviour Methods
    private void Awake()
    {
        _idleStateHash = Animator.StringToHash("Idle");
        _showAndSettleStateHash = Animator.StringToHash("ShowAndSettle");
        _showAndSettleReverseStateHash = Animator.StringToHash("ShowAndSettleReverse");
    }
    #endregion
    
    public void OnShowAndSettleAnimationEnd()
    {
        _onShowAndSettleEndResponse?.Invoke();
    }
    
    public void OnShowAndSettleReverseAnimationEnd()
    {
        _onShowAndSettleReverseEndResponse?.Invoke();
    }
    
    public void PlayIdleAnimation()
    {
        _animator.Play(_idleStateHash);
    }
    
    public void PlayShowAndSettleAnimation()
    {
        _animator.Play(_showAndSettleStateHash);
    }
    public void PlayShowAndSettleReverseAnimation()
    {
        _animator.Play(_showAndSettleReverseStateHash);
    }
}

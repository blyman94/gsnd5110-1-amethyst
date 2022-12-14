using UnityEngine;
using UnityEngine.Events;

public class IconAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private UnityEvent _onShowAndSettleEndResponse;
    [SerializeField] private UnityEvent _onShowAndSettleReverseEndResponse;
    [SerializeField] private UnityEvent _onShowFromRightEndResponse;
    [SerializeField] private UnityEvent _onSettleRightEndResponse;
    
    private int _idleStateHash;
    private int _showAndSettleStateHash;
    private int _showAndSettleReverseStateHash;
    private int _showFromRightStateHash;
    private int _settleRightStateHash;
    
    #region MonoBehaviour Methods
    private void Awake()
    {
        _idleStateHash = Animator.StringToHash("Idle");
        _showAndSettleStateHash = Animator.StringToHash("ShowAndSettle");
        _showAndSettleReverseStateHash = Animator.StringToHash("ShowAndSettleReverse");
        _showFromRightStateHash = Animator.StringToHash("ShowFromRight");
        _settleRightStateHash = Animator.StringToHash("SettleRight");
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

    public void OnSettleRightAnimationEnd()
    {
        _onSettleRightEndResponse?.Invoke();
    }
    
    public void OnShowFromRightAnimationEnd()
    {
        _onShowFromRightEndResponse?.Invoke();
    }
    
    public void PlayIdleAnimation()
    {
        _animator.Play(_idleStateHash);
    }
    
    public void PlayShowFromRightAnimation()
    {
        _animator.Play(_showFromRightStateHash);
    }
    
    public void PlaySettleRightAnimation()
    {
        _animator.Play(_settleRightStateHash);
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

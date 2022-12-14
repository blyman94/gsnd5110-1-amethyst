using UnityEngine;
using UnityEngine.Events;

public class CanvasGroupFader : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private bool startShowing;
    
    [Header("Shown State Parameters")]
    [SerializeField] private float _shownAlpha = 1.0f;
    [SerializeField] private bool _shownBlocksRaycasts = true;
    [SerializeField] private bool _shownInteractable = true;

    [Header("Events")] 
    [SerializeField] private UnityEvent _fadeInCompleteEvent;
    [SerializeField] private UnityEvent _fadeOutCompleteEvent;

    private float _fadeTime;
    private float _elapsedTime;
    private bool _fadingIn;
    private bool _fadingOut;

    #region MonoBehaviour Methods

    private void Start()
    {
        if (startShowing)
        {
            _canvasGroup.alpha = _shownAlpha;
            _canvasGroup.blocksRaycasts = _shownBlocksRaycasts;
            _canvasGroup.interactable = _shownInteractable;
        }
        else
        {
            _canvasGroup.alpha = 0.0f;
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.interactable = false;
        }
    }
    private void Update()
    {
        if (_fadingIn)
        {
            _canvasGroup.alpha = Mathf.Lerp(0.0f, _shownAlpha,
                _elapsedTime / _fadeTime);
            _elapsedTime += Time.deltaTime;
            if (_canvasGroup.alpha >= _shownAlpha)
            {
                _fadeInCompleteEvent?.Invoke();
                _fadingIn = false;
                _canvasGroup.alpha = _shownAlpha;
                _canvasGroup.blocksRaycasts = _shownBlocksRaycasts;
                _canvasGroup.interactable = _shownInteractable;
            }
        }
        else if (_fadingOut)
        {
            _canvasGroup.alpha = Mathf.Lerp(_shownAlpha, 0.0f,
                _elapsedTime / _fadeTime);
            _elapsedTime += Time.deltaTime;
            if (_canvasGroup.alpha <= 0.0f)
            {
                _fadeOutCompleteEvent?.Invoke();
                _fadingOut = false;
                _canvasGroup.alpha = 0.0f;
            }
        }
    }
    #endregion
    
    public void FadeOut(float fadeTime)
    {
        _fadingOut = true;
        _fadingIn = false;
        
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
        
        _canvasGroup.alpha = _shownAlpha;
        _fadeTime = fadeTime;
        _elapsedTime = 0.0f;
    }

    public void FadeInIfNeeded(float fadeTime)
    {
        if (!(_canvasGroup.alpha == 1))
        {
            FadeIn(fadeTime);
        }
    }
    
    public void FadeOutIfNeeded(float fadeTime)
    {
        if (!(_canvasGroup.alpha == 0))
        {
            FadeOut(fadeTime);
        }
    }
    
    public void FadeIn(float fadeTime)
    {
        _fadingOut = false;
        _fadingIn = true;
        
        _canvasGroup.alpha = 0.0f;
        _fadeTime = fadeTime;
        _elapsedTime = 0.0f;
    }
}

using System.Collections;
using UnityEngine;

/// <summary>
/// Utility to show and hide CanvasGroups representing menus in the game's UI.
/// Works very cleanly with GameEventListeners.
/// </summary>
[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupRevealer : MonoBehaviour
{
    /// <summary>
    /// Should this canvas group fade in?
    /// </summary>
    [Tooltip("Should this canvas group fade in?")]
    [SerializeField] private bool _canvasFadeIn;

    /// <summary>
    /// Should this canvas group fade out?
    /// </summary>
    [Tooltip("Should this canvas group fade out?")]
    [SerializeField] private bool _canvasFadeOut;

    /// <summary>
    /// Animation curve depicting the pattern of the fade.
    /// </summary>
    [Tooltip("Animation curve depicting the pattern of the fade.")]
    [SerializeField] private AnimationCurve _fadeCurve;

    /// <summary>
    /// How long should it take for this canvas to fade in or out?
    /// </summary>
    [Tooltip("How long should it take for this canvas to fade in or out?")]
    [SerializeField] private float _fadeTime;

    /// <summary>
    /// The alpha value this CanvasGroup will have when in the shown state.
    /// </summary>
    [Tooltip("The alpha value this CanvasGroup will have when in the shown " +
        "state")]
    [SerializeField, Range(0.0f, 1.0f)] private float _shownAlpha = 1;

    /// <summary>
    /// The BlockRaycast value this CanvasGroup will have when in the 
    /// shown state.
    /// </summary>
    [Tooltip("The BlockRaycast value this CanvasGroup will have when in the" +
        "shown state.")]
    [SerializeField] private bool _shownBlockRaycast = true;

    /// <summary>
    /// The Interactable value this Canvas group will have when in 
    /// the shown state.
    /// </summary>
    [Tooltip("The Interactable value this Canvas group will have when in the " +
        "shown state.")]
    [SerializeField] private bool _shownInteractable = true;

    /// <summary>
    /// Should this CanvasGroup start hidden?
    /// </summary>
    [Tooltip("Should this CanvasGroup start hidden?")]
    [SerializeField] private bool _startHidden = false;

    /// <summary>
    /// CanvasGroup component to be shown and hidden.
    /// </summary>
    private CanvasGroup _canvasGroup;

    /// <summary>
    /// Current active coroutine for proper cancellation.
    /// </summary>
    private IEnumerator _activeCoroutine;

    #region Properties
    /// <summary>
    /// Tracks whether the Canvas group is currently shown or hidden.
    /// </summary>
    public bool Shown { get; set; } = true;
    #endregion

    #region MonoBehaviour Methods
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        if (_startHidden)
        {
            Shown = false;
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.interactable = false;
        }
    }
    #endregion

    /// <summary>
    /// Hides the CanvasGroup. Alpha is set to zero, BlockRaycasts is set to 
    /// false and Interactable is set to false.
    /// </summary>
    public void HideGroup()
    {
        if (_canvasFadeOut)
        {
            FadeOut();
        }
        else
        {
            Shown = false;
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.interactable = false;
        }
    }

    /// <summary>
    /// Shows the CanvasGroup. Assigns shown state parameters Alpha,
    /// BlockRaycast and Interactable.
    /// </summary>
    public void ShowGroup()
    {
        if (_canvasFadeIn)
        {
            FadeIn();
        }
        else
        {
            Shown = true;
            _canvasGroup.alpha = _shownAlpha;
            _canvasGroup.blocksRaycasts = _shownBlockRaycast;
            _canvasGroup.interactable = _shownInteractable;
        }
    }

    /// <summary>
    /// Shows the CanvasGroup if its hidden, hides the canvas group if its 
    /// shown.
    /// </summary>
    public void ToggleGroup()
    {
        if (Shown)
        {
            HideGroup();
        }
        else
        {
            ShowGroup();
        }
    }

    /// <summary>
    /// Stops the active coroutine and fades in the CanvasGroup.
    /// </summary>
    private void FadeIn()
    {
        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
        }
        _activeCoroutine = FadeInGroupRoutine();
        StartCoroutine(_activeCoroutine);
    }

    /// <summary>
    /// Stops the active coroutine and fades out the CanvasGroup.
    /// </summary>
    private void FadeOut()
    {
        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
        }
        _activeCoroutine = FadeOutGroupRoutine();
        StartCoroutine(_activeCoroutine);
    }

    /// <summary>
    /// Routine to fade in the CanvasGroup.
    /// </summary>
    /// <returns>IEnumerator returned to suspend iteration.</returns>
    private IEnumerator FadeInGroupRoutine()
    {
        float elapsedTime = 0.0f;
        float currentAlpha = _canvasGroup.alpha;

        while (elapsedTime < _fadeTime)
        {
            _canvasGroup.alpha = Mathf.Lerp(currentAlpha, _shownAlpha,
                _fadeCurve.Evaluate(elapsedTime / _fadeTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _canvasGroup.alpha = _shownAlpha;

        Shown = true;
        _canvasGroup.blocksRaycasts = _shownBlockRaycast;
        _canvasGroup.interactable = _shownInteractable;
    }

    /// <summary>
    /// Routine to fade out the CanvasGroup.
    /// </summary>
    /// <returns>IEnumerator returned to suspend iteration.</returns>
    private IEnumerator FadeOutGroupRoutine()
    {
        float elapsedTime = 0.0f;
        float currentAlpha = _canvasGroup.alpha;

        while (elapsedTime < _fadeTime)
        {
            _canvasGroup.alpha = Mathf.Lerp(currentAlpha, 0.0f,
                _fadeCurve.Evaluate(elapsedTime / _fadeTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Shown = false;
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
    }
}
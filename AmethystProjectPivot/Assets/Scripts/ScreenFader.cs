using System.Collections;
using UnityEngine;

public class ScreenFader : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    [Header("Fade Behaviour")]
    [SerializeField] private float _fadeInTime;
    [SerializeField] private float _holdTime;
    [SerializeField] private float _fadeOutTime;

    [Header("Events")]
    [SerializeField] private GameEvent _rasiedMidFade;

    private bool initialFade = true;
    private IEnumerator _activeCoroutine;

    #region MonoBehaviour Methods
    private void Start()
    {
        StartFade();
    }
    #endregion

    /// <summary>
    /// Stops the active coroutine and fades in the CanvasGroup.
    /// </summary>
    public void StartFade()
    {
        _activeCoroutine = FadeRoutine();
        StartCoroutine(_activeCoroutine);
    }

    public void StopFade()
    {
        StopCoroutine(_activeCoroutine);
    }

    /// <summary>
    /// Routine to fade in the CanvasGroup.
    /// </summary>
    /// <returns>IEnumerator returned to suspend iteration.</returns>
    private IEnumerator FadeRoutine()
    {
        // Fade In
        float elapsedTime = 0.0f;
        float currentAlpha = _canvasGroup.alpha;

        if (!initialFade)
        {
            while (elapsedTime < _fadeInTime)
            {
                _canvasGroup.alpha = Mathf.Lerp(currentAlpha, 1.0f, elapsedTime / _fadeInTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            _canvasGroup.alpha = 1.0f;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.interactable = true;

            // Raise midway event
            _rasiedMidFade.Raise();

        }

        initialFade = false;

        // Hold
        elapsedTime = 0.0f;
        while (elapsedTime < _holdTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Fade Out
        elapsedTime = 0.0f;
        currentAlpha = _canvasGroup.alpha;

        while (elapsedTime < _fadeOutTime)
        {
            _canvasGroup.alpha = Mathf.Lerp(currentAlpha, 0.0f, elapsedTime / _fadeOutTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
    }
}



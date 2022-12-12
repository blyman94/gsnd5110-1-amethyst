using TMPro;
using UnityEngine;

public class OscillateTextSize : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textToResize;
    [SerializeField] private float _baseTextSize = -1.0f;
    [SerializeField] private float _textSizeVariance = 2.0f;
    [SerializeField] private float _oscillationSpeed = 1.0f;
    [SerializeField] private bool _isOscillating = false;

    private float _minTextSize;
    private float _maxTextSize;
    
    #region MonoBehaviour Methods
    private void Awake()
    {
        if (_baseTextSize == -1.0f)
        {
            _baseTextSize = _textToResize.fontSize;
        }
        _minTextSize = _baseTextSize - _textSizeVariance;
        _maxTextSize = _baseTextSize + _textSizeVariance;
    }
    private void Update()
    {
        if (_isOscillating)
        {
            float t = (Mathf.Sin (Time.time * _oscillationSpeed * Mathf.PI * 2.0f) + 1.0f) / 2.0f;
            _textToResize.fontSize = Mathf.Lerp (_minTextSize, _maxTextSize, t);
        }
    }
    #endregion

    public void StartOscillation()
    {
        _isOscillating = true;
    }

    public void StopOscillation()
    {
        _isOscillating = false;
        _textToResize.fontSize = _baseTextSize;
    }
}

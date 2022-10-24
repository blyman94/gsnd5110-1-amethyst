using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Binds a slider's value to that of a FloatVariable ScriptableObject.
/// </summary>
public class SliderValueFloatBinding : MonoBehaviour
{
    /// <summary>
    /// Slider to be updated by variable.
    /// </summary>
    [Tooltip("Slider to be updated by variable.")]
    [SerializeField] private Slider _slider;

    /// <summary>
    /// Variable used to update the slider.
    /// </summary>
    [Tooltip("Variable used to update the slider.")]
    [SerializeField] private FloatVariable _boundFloatVariable;

    #region MonoBehaviour Methods
    private void OnEnable()
    {
        _boundFloatVariable.VariableUpdated += UpdateSliderValue;
    }
    private void Start()
    {
        _slider.value = _boundFloatVariable.Value;
    }
    private void OnDisable()
    {
        _boundFloatVariable.VariableUpdated -= UpdateSliderValue;
    }
    #endregion

    private void UpdateSliderValue()
    {
        _slider.value = _boundFloatVariable.Value;
    }
}

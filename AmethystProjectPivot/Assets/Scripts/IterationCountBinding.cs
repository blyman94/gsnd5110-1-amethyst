using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IterationCountBinding : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dayText;
    [SerializeField] private IntVariable _iterationCount;

    #region MonoBehaviour Methods
    private void OnEnable()
    {
        _iterationCount.VariableUpdated += UpdateDayText;
    }
    private void OnDisable()
    {
        _iterationCount.VariableUpdated -= UpdateDayText;
    }
    #endregion

    private void UpdateDayText()
    {
        _dayText.text = "Day " + _iterationCount.Value;
    }
}

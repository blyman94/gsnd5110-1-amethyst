using TMPro;
using UnityEngine;

public class IntVariableBinding : MonoBehaviour
{
    [SerializeField] private IntVariable _intVariable;
    [SerializeField] private TextMeshProUGUI _boundText;
    [SerializeField] private bool _bindTextOnStart;

    public IntVariable IntVariable
    {
        get
        {
            return _intVariable;
        }
        set
        {
            _intVariable = value;
            UpdateBindingUI();
        }
    }
    #region MonoBehavior Methods
    private void OnEnable()
    {
        _intVariable.VariableUpdated += UpdateBindingUI;
    }

    private void Start()
    {
        if (_bindTextOnStart)
        {
            UpdateBindingUI();
        }
    }
    private void OnDisable()
    {
        _intVariable.VariableUpdated -= UpdateBindingUI;
    }
    #endregion

    private void UpdateBindingUI()
    {
        _boundText.text = _intVariable.Value.ToString();
    }
}

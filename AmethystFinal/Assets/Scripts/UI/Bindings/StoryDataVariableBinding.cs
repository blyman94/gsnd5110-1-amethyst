using TMPro;
using UnityEngine;

public class StoryDataVariableBinding : MonoBehaviour
{
    [SerializeField] private StoryDataVariable _storyDataVariable;
    [SerializeField] private PostDecisionVariable _postDecisionVariable;
    [SerializeField] private bool _bindTextOnStart;

    [Header("Bound Text Fields")] 
    [SerializeField] private TextMeshProUGUI _comment0Text;
    [SerializeField] private TextMeshProUGUI _comment1Text;
    [SerializeField] private TextMeshProUGUI _comment2Text;

    public StoryDataVariable StoryDataVariable
    {
        get
        {
            return _storyDataVariable;
        }
        set
        {
            _storyDataVariable = value;
            UpdateBindingUI();
        }
    }
    #region MonoBehavior Methods
    private void OnEnable()
    {
        _storyDataVariable.VariableUpdated += UpdateBindingUI;
        _postDecisionVariable.VariableUpdated += UpdateBindingUI;
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
        _storyDataVariable.VariableUpdated -= UpdateBindingUI;
        _postDecisionVariable.VariableUpdated -= UpdateBindingUI;
    }
    #endregion

    private void UpdateBindingUI()
    {
        if (_postDecisionVariable.Value == PostDecision.Anonymous)
        {
            UpdateBindingUIAnonymous();
        }
        else if (_postDecisionVariable.Value == PostDecision.Government)
        {
            UpdateBindingUIGovernment();
        }
    }

    private void UpdateBindingUIAnonymous()
    {
        if (_comment0Text != null &&
            _storyDataVariable.Value.AnonymousCommentsToDisplay[0] != null)
        {
            _comment0Text.text = _storyDataVariable.Value.AnonymousCommentsToDisplay[0];
        }
        if (_comment1Text != null &&
            _storyDataVariable.Value.AnonymousCommentsToDisplay[1] != null)
        {
            _comment1Text.text = _storyDataVariable.Value.AnonymousCommentsToDisplay[1];
        }
        if (_comment2Text != null &&
            _storyDataVariable.Value.AnonymousCommentsToDisplay[2] != null)
        {
            _comment2Text.text = _storyDataVariable.Value.AnonymousCommentsToDisplay[2];
        }
    }
    
    private void UpdateBindingUIGovernment()
    {
        if (_comment0Text != null &&
            _storyDataVariable.Value.GovernmentCommentsToDisplay.Length >= 1)
        {
            _comment0Text.text = _storyDataVariable.Value.GovernmentCommentsToDisplay[0];
        }
        if (_comment1Text != null &&
            _storyDataVariable.Value.GovernmentCommentsToDisplay.Length >= 2)
        {
            _comment1Text.text = _storyDataVariable.Value.GovernmentCommentsToDisplay[1];
        }
        if (_comment2Text != null &&
            _storyDataVariable.Value.GovernmentCommentsToDisplay.Length >= 3)
        {
            _comment2Text.text = _storyDataVariable.Value.GovernmentCommentsToDisplay[2];
        }
    }
}

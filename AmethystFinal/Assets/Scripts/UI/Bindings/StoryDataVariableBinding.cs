using TMPro;
using UnityEngine;

public class StoryDataVariableBinding : MonoBehaviour
{
    [SerializeField] private StoryDataVariable _storyDataVariable;
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
    }
    #endregion

    private void UpdateBindingUI()
    {
        if (_comment0Text != null &&
            _storyDataVariable.Value.CommentsToDisplay[0] != null)
        {
            _comment0Text.text = _storyDataVariable.Value.CommentsToDisplay[0];
        }
        if (_comment1Text != null &&
            _storyDataVariable.Value.CommentsToDisplay[1] != null)
        {
            _comment1Text.text = _storyDataVariable.Value.CommentsToDisplay[1];
        }
        if (_comment2Text != null &&
            _storyDataVariable.Value.CommentsToDisplay[2] != null)
        {
            _comment2Text.text = _storyDataVariable.Value.CommentsToDisplay[2];
        }
    }
}

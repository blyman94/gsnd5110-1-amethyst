using TMPro;
using UnityEngine;

public class StoryDataBinding : MonoBehaviour
{
    [SerializeField] private StoryData _storyData;
    [SerializeField] private TextMeshProUGUI _storyTitleText;
    [SerializeField] private TextMeshProUGUI _storyDetailsText;
    [SerializeField] private StoryDataVariable _activeStory;

    public StoryData StoryData
    {
        get
        {
            return _storyData;
        }
        set
        {
            _storyData = value;
            UpdateStoryDataDisplay();
        }
    }
    
    #region MonoBehaviour Methods
    private void Start()
    {
        UpdateStoryDataDisplay();
    }
    #endregion

    public void UpdateActiveStory()
    {
        _activeStory.Value = _storyData;
    }

    private void UpdateStoryDataDisplay()
    {
        if (_storyData != null)
        {
            if (_storyTitleText != null)
            {
                _storyTitleText.text = _storyData.Title;
            }

            if (_storyDetailsText != null)
            {
                _storyDetailsText.text = _storyData.Description;
            }
        }
        else
        {
            _storyTitleText.text = "";
            _storyDetailsText.text = "";
        }
    }
}

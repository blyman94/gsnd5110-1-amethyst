using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StoryDataBinding : MonoBehaviour
{
    [SerializeField] private StoryData _storyData;
    [SerializeField] private TextMeshProUGUI _storyTitleText;
    [SerializeField] private TextMeshProUGUI _storyDetailsText;
    [SerializeField] private StoryDataVariable _activeStory;
    [SerializeField] private bool isAnonymousDisplay = false;
    [SerializeField] private bool showSpin = false;

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
        string titleText = "";
        string detailsText = "";
        
        if (_storyData != null)
        {
            if (_storyData.SpinStory && showSpin)
            {
                if (isAnonymousDisplay)
                {
                    titleText = _storyData.AnonymousTitle;
                    detailsText = _storyData.AnonymousDescription;
                }
                else
                {
                    titleText = _storyData.GovernmentTitle;
                    detailsText = _storyData.GovernmentDescription;
                }
            }
            else
            {
                titleText = _storyData.Title;
                detailsText = _storyData.Description;
            }
        }
        
        if (_storyTitleText != null)
        {
            _storyTitleText.text = titleText;
                
        }

        if (_storyDetailsText != null)
        {
            _storyDetailsText.text = detailsText;
        }
    }
}

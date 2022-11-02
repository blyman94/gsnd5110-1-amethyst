using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI Component that displays breif information about a story in the story 
/// feed.
/// </summary>
public class StoryDisplay : MonoBehaviour
{
    /// <summary>
    /// The story to be displayed in this UI object.
    /// </summary>
    [SerializeField] private SocialMediaStory _storyToDisplay;

    /// <summary>
    /// Text object to display the story's title.
    /// </summary>
    [SerializeField] private TextMeshProUGUI _storyTitleText;

    /// <summary>
    /// The global active story.
    /// </summary>
    [SerializeField] private SocialMediaStoryVariable _activeStory;

    [SerializeField] private Image _backgroundImage;

    [SerializeField] private Color _postInternalColor;
    [SerializeField] private Color _postExternalColor;
    [SerializeField] private Color _doNotPostColor;

    /// <summary>
    /// The story to be displayed in this UI object.
    /// </summary>
    public SocialMediaStory StoryToDisplay
    {
        get
        {
            return _storyToDisplay;
        }
        set
        {
            _storyToDisplay = value;
            UpdateDisplay();
        }
    }

    #region MonoBehaviour Methods
    private void Start()
    {
        _storyToDisplay.StateUpdated += UpdateDisplay;
        UpdateDisplay();
    }
    private void OnDisable()
    {
        _storyToDisplay.StateUpdated -= UpdateDisplay;
    }
    #endregion

    /// <summary>
    /// Sets the global active story to this display's story to display.
    /// </summary>
    public void SetActiveStory()
    {
        _activeStory.Value = _storyToDisplay;
    }

    /// <summary>
    /// Updates the StoryDisplay with the title text of the story to display.
    /// </summary>
    private void UpdateDisplay()
    {
        Debug.Log("UpdateDisplay Called");
        if (_storyToDisplay != null)
        {
            _storyTitleText.text = _storyToDisplay.Title;

            if (_storyToDisplay.PostExternal)
            {
                _backgroundImage.color = _postExternalColor;
            }
            else if (_storyToDisplay.PostInternal)
            {
                _backgroundImage.color = _postInternalColor;
            }
            else
            {
                _backgroundImage.color = _doNotPostColor;
            }
        }
    }
}

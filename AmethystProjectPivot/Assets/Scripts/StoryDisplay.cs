using TMPro;
using UnityEngine;

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
        UpdateDisplay();
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
        if (_storyToDisplay != null)
        {
            _storyTitleText.text = _storyToDisplay.Title;
        }
    }
}

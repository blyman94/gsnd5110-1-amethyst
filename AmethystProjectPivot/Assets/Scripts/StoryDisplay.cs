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
    [SerializeField] private Story _storyToDisplay;

    /// <summary>
    /// Text object to display the story's title.
    /// </summary>
    [SerializeField] private TextMeshProUGUI _storyTitleText;

    /// <summary>
    /// The global active story.
    /// </summary>
    [SerializeField] private StoryVariable _activeStory;

    /// <summary>
    /// Background image of the story display that will change color based on
    /// the player's posting decision.
    /// </summary>
    [SerializeField] private Image _backgroundImage;

    [SerializeField] private Color _postExternalColor = Color.magenta;
    [SerializeField] private Color _postInternalColor = Color.cyan;
    [SerializeField] private Color _doNotPostColor = Color.white;

    /// <summary>
    /// The story to be displayed in this UI object.
    /// </summary>
    public Story StoryToDisplay
    {
        get
        {
            return _storyToDisplay;
        }
        set
        {
            _storyToDisplay = value;

            if (_storyToDisplay != null)
            {
                _storyToDisplay.PostDecisionUpdated += UpdateDisplay;
            }

            UpdateDisplay();
        }
    }

    #region MonoBehaviour Methods
    private void Start()
    {
        UpdateDisplay();
    }
    private void OnDisable()
    {
        if (_storyToDisplay != null)
        {
            _storyToDisplay.PostDecisionUpdated -= UpdateDisplay;
        }
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

            switch (_storyToDisplay.PostDecision)
            {
                case (PostDecision.External):
                    _backgroundImage.color = _postExternalColor;
                    break;
                case (PostDecision.Internal):
                    _backgroundImage.color = _postInternalColor;
                    break;
                case (PostDecision.DoNot):
                    _backgroundImage.color = _doNotPostColor;
                    break;
                default:
                    _backgroundImage.color = _doNotPostColor;
                    break;
            }
        }
    }
}

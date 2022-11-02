using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryDetailsDisplay : MonoBehaviour
{
    /// <summary>
    /// The global active story.
    /// </summary>
    [SerializeField] private SocialMediaStoryVariable _activeStory;

    /// <summary>
    /// Text object to display the story's title.
    /// </summary>
    [SerializeField] private TextMeshProUGUI _storyTitleText;

    /// <summary>
    /// Text object to display the story's body.
    /// </summary>
    [SerializeField] private TextMeshProUGUI _storyBodyText;

    /// <summary>
    /// Text object to display the related story's title
    /// </summary>
    [SerializeField] private TextMeshProUGUI _relatedStoryTitleText;

    #region MonoBehaviour Methods
    private void OnEnable()
    {
        _activeStory.VariableUpdated += UpdateDisplay;
    }
    private void OnDisable()
    {
        _activeStory.VariableUpdated -= UpdateDisplay;
    }
    #endregion

    /// <summary>
    /// Updates the StoryDetails display to reflect the active story.
    /// </summary>
    private void UpdateDisplay()
    {
        _storyTitleText.text = _activeStory.Value.Title;
        _storyBodyText.text = _activeStory.Value.Body;
        _relatedStoryTitleText.text = "Related Story: " + "None";
    }

    public void PostStoryExternal()
    {
        _activeStory.Value.PostExternal = true;
        _activeStory.Value.PostInternal = false;
        Debug.Log("Called");
        _activeStory.Value.SignalStateUpdate();
    }

    public void PostStoryInternal()
    {
        _activeStory.Value.PostExternal = false;
        _activeStory.Value.PostInternal = true;
        _activeStory.Value.SignalStateUpdate();
    }

    public void DoNotPostStory()
    {
        _activeStory.Value.PostExternal = false;
        _activeStory.Value.PostInternal = false;
        _activeStory.Value.SignalStateUpdate();
    }
}

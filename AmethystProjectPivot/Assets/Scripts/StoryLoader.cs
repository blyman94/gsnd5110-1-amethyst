using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryLoader : MonoBehaviour
{
    /// <summary>
    /// List of stories to be displayed on the feed.
    /// </summary>
    [SerializeField] private List<SocialMediaStory> _storiesToLoad;

    /// <summary>
    /// Prefab of the StoryDisplay object.
    /// </summary>
    [SerializeField] private GameObject _storyDisplayPrefab;

    /// <summary>
    /// Transform who will act as the parent to each StoryDisplay created.
    /// </summary>
    [SerializeField] private Transform _storyParentTransform;

    #region MonoBehaviour Methods
    private void Start()
    {
        foreach (SocialMediaStory story in _storiesToLoad)
        {
            GameObject storyDisplayObject = 
                Instantiate(_storyDisplayPrefab, _storyParentTransform);
            StoryDisplay storyDisplay = 
                storyDisplayObject.GetComponent<StoryDisplay>();
            storyDisplay.StoryToDisplay = story;
        }
    }
    #endregion
}
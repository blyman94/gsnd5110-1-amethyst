using UnityEngine;

public delegate void StateUpdated();

/// <summary>
/// Represents a SocialMediaPost object that the player can choose to post 
/// internally, externally, or withold.
/// </summary>
[CreateAssetMenu]
public class SocialMediaStory : ScriptableObject
{
    /// <summary>
    /// What will the header of this post be?
    /// </summary>
    [TextArea(1, 1)]
    [Tooltip("What will the header of this post be?")]
    public string Title;

    /// <summary>
    /// What will the body of this post be?
    /// </summary>
    [TextArea(5, 5)]
    [Tooltip("What will the body of this post be?")]
    public string Body;

    /// <summary>
    /// Will this story be posted externally?
    /// </summary>
    public bool PostExternal = false;

    /// <summary>
    /// Will this story be posted internally?
    /// </summary>
    public bool PostInternal = false;

    /// <summary>
    /// Will this story be witheld?
    /// </summary>
    public bool Unposted
    {
        get
        {
            return (!PostExternal && !PostInternal);
        }
    }

    public StateUpdated StateUpdated;

    public void SignalStateUpdate()
    {
        StateUpdated?.Invoke();
    }
}

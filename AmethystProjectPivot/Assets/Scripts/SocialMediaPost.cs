using UnityEngine;

/// <summary>
/// Represents a SocialMediaPost object that the player can choose to post 
/// internally, externally, or withold.
/// </summary>
[CreateAssetMenu]
public class SocialMediaPost : ScriptableObject
{
    /// <summary>
    /// What will the header of this post be?
    /// </summary>
    [TextArea(1,1)]
    [Tooltip("What will the header of this post be?")]
    public string Header;

    /// <summary>
    /// What will the body of this post be?
    /// </summary>
    [TextArea(5,5)]
    [Tooltip("What will the body of this post be?")]
    public string Body;
}

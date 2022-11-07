using UnityEngine;

/// <summary>
/// Represents a story that the player can choose to post internally, 
/// externally, or withold.
/// </summary>
[CreateAssetMenu]
public class Story : ScriptableObject
{
    public PostDecisionUpdated PostDecisionUpdated;

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
    /// What is the post decision of this story?
    /// </summary>
    [Tooltip("What is the post decision of this story?")]
    public PostDecision PostDecision
    {
        get
        {
            return _postDecision;
        }
        set
        {
            _postDecision = value;
            PostDecisionUpdated?.Invoke();
        }
    }

    /// <summary>
    /// Iteration this story should be posted on.
    /// </summary>
    [Tooltip("Iteration this story should be posted on.")]
    public int WhenToPost = 0;

    /// <summary>
    /// Which story is this story a result of?
    /// </summary>
    [Tooltip("Which story is this story a result of?")]
    public Story PreviousStory;

    /// <summary>
    /// What story results from this one being posted externally?
    /// </summary>
    [Tooltip("What story results from this one being posted externally?")]
    public Story PostedExternallyResult;

    /// <summary>
    /// What story results from this one being posted internally?
    /// </summary>
    [Tooltip("What story results from this one being posted internally?")]
    public Story PostedInternallyResult;

    /// <summary>
    /// What story results from this one not being posted?
    /// </summary>
    [Tooltip("What story results from this one not being posted?")]
    public Story NotPostedResult;

    /// <summary>
    /// What is the post decision of this story?
    /// </summary>
    [Tooltip("What is the post decision of this story?")]
    [SerializeField] private PostDecision _postDecision = PostDecision.DoNot;
}

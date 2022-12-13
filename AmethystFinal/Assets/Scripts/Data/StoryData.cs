using UnityEngine;

[CreateAssetMenu]
public class StoryData : ScriptableObject
{
    [Header("General")]
    public string Title = "New Story Title";
    [TextArea(5, 5)] 
    public string Description = "New story details...";

    [Header("Metrics Data")] 
    public int FollowerDelta = 25;
    public int CommentDelta = 2;
    public string[] CommentsToDisplay;
}

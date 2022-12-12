using UnityEngine;

[CreateAssetMenu]
public class StoryData : ScriptableObject
{
    [Header("General")]
    public string Title = "New Story Title";
    [TextArea(5, 5)] 
    public string Description = "New story details...";
    
    [Header("Comment Data")] 
    public int TotalComments;
    public string[] CommentsToDisplay;
}

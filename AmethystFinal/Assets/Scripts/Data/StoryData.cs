using UnityEngine;

[CreateAssetMenu]
public class StoryData : ScriptableObject
{
    [Header("General")]
    public string Title = "New Story Title";
    [TextArea(5, 5)] 
    public string Description = "New story details...";
    public int AvailableStartingDay = 0;
    
    [Header("Comments")]
    public string[] AnonymousCommentsToDisplay;
    public string[] GovernmentCommentsToDisplay;
    
    [Header("Player Score Data (Anonymous, Government)")] 
    public Vector2Int FollowerDelta = new Vector2Int(25,35);
    public Vector2Int CommentDelta = new Vector2Int(4,6);

    [Header("Storyline Data")] 
    public StoryData AnonymousResult;
    public StoryData GovernmentResult;
    public StoryData DoNotPostResult;

}

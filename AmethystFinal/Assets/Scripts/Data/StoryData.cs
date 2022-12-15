using UnityEngine;

[CreateAssetMenu]
public class StoryData : ScriptableObject
{
    [Header("General")]
    public string Title = "New Story Title";
    [TextArea(5, 5)] 
    public string Description = "New story details...";
    public bool IsMainStory = false;
    public int AvailableStartingDay = 1;

    [Header("Story Spin Data")] 
    public bool SpinStory = false;
    public string AnonymousTitle;
    [TextArea(5,5)]
    public string AnonymousDescription;
    public string GovernmentTitle;
    [TextArea(5,5)]
    public string GovernmentDescription;
    
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
    [TextArea(5,5)]
    public string ResolutionSummary;

}

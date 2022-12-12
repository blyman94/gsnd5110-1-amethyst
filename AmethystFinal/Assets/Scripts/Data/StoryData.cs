using UnityEngine;

[CreateAssetMenu]
public class StoryData : ScriptableObject
{
    public string Title = "New Story Title";
    [TextArea(5, 5)] 
    public string Description = "New story details...";
}

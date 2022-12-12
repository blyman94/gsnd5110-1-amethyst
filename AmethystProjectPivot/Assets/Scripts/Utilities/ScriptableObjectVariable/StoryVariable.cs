using UnityEngine;

/// <summary>
/// Story Scriptable Object Variable.
/// </summary>
[CreateAssetMenu(menuName = "Scriptable Object Variable/Story",
    fileName = "New Story Variable")]
public class StoryVariable : ScriptableObjectVariable<Story>
{
    public void PostInternally()
    {
        Value.PostDecision = PostDecision.Internal;
    }
    public void PostedExternally()
    {
        Value.PostDecision = PostDecision.External;
    }
    public void DoNotPost()
    {
        Value.PostDecision = PostDecision.DoNot;
    }
}

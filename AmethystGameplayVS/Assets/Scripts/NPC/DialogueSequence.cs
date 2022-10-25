using UnityEngine;

/// <summary>
/// The structure of a dialogue interaction.
/// </summary>
[CreateAssetMenu]
public class DialogueSequence : ScriptableObject
{   
    /// <summary>
    /// String upon which this dialogue sequence will begin.
    /// </summary>
    [Tooltip("String upon which this dialogue sequence will begin.")]
    public DialogueString StartDialogueString;

    /// <summary>
    /// What does this NPC require of the player to give more information?
    /// </summary>
    [Tooltip("What does this NPC require of the player to give more " + 
        "information?")]
    public DialogueCondition DialogueCondition;
}

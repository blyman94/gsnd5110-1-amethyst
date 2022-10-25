using UnityEngine;

/// <summary>
/// Holds a public reference to the NPCData ScriptableObject.
/// </summary>
public class NPC : MonoBehaviour
{
    /// <summary>
    /// Data representing this NPC.
    /// </summary>
    [Tooltip("Data representing this NPC.")]
    public NPCData NPCData;
}

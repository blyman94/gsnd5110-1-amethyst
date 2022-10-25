using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Data pertaining to a Non-Player Character.
/// </summary>
[CreateAssetMenu]
public class NPCData : ScriptableObject
{
    /// <summary>
    /// Name of the NPC.
    /// </summary>
    [Tooltip("Name of the NPC.")]
    public string Name;

    /// <summary>
    /// Portrait of the NPC.
    /// </summary>
    [Tooltip("Portrait of the NPC.")]
    public Sprite PortraitSprite;
}

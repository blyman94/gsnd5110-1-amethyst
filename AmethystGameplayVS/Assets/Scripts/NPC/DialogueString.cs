using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScriptableObject representation of a string of dialogue.
/// </summary>
[CreateAssetMenu]
public class DialogueString : ScriptableObject
{
    /// <summary>
    /// What should this dialogue string contain?
    /// </summary>
    [Tooltip("What should this dialogue string contain?")]
    [TextArea(5,5)]
    public string Value;
}

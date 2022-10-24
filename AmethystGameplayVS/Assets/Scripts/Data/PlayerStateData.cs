using UnityEngine;

/// <summary>
/// Tracks data about the player state, including energy, productivity, 
/// evidence, and mood.
/// </summary>
[CreateAssetMenu]
public class PlayerStateData : ScriptableObject
{
    /// <summary>
    /// How much energy does the player have?
    /// </summary>
    [Tooltip("How much energy does the player have?")]
    public float Energy;

    /// <summary>
    /// What level of productivity does the player have?
    /// </summary>
    [Tooltip("What level of productivity does the player have?")]
    public float Productivity;

    /// <summary>
    /// How much evidence does the player have?
    /// </summary>
    [Tooltip("How much evidence does the player have?")]
    public float Evidence;

    /// <summary>
    /// What color will this location change the mood ring to?
    /// </summary>
    [Tooltip("What color will this location change the mood ring to?")]
    public Color MoodColor = Color.white;
}

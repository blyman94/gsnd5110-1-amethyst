using UnityEngine;

/// <summary>
/// Stores information about a location and how it affects player state.
/// </summary>
[CreateAssetMenu]
public class LocationData : ScriptableObject
{
    /// <summary>
    /// Location's name.
    /// </summary>
    [Tooltip("Location's name.")]
    public string Name;

    /// <summary>
    /// By how much does this location change the player's energy, per second?
    /// </summary>
    [Tooltip("By how much does this location change the player's energy, " + 
        "per second?")]
    public float EnergyChangePerSecond;

    /// <summary>
    /// By how much does this location change the player's productivity, 
    /// per second?
    /// </summary>
    [Tooltip("By how much does this location change the player's " + 
        "productivity, per second?")]
    public float ProductivityChangePerSecond;

    /// <summary>
    /// By how much does this location change the player's evidence gathered, 
    /// per second?
    /// </summary>
    [Tooltip("By how much does this location change the player's " + 
        "evidence gathered, per second?")]
    public float EvidenceChangePerSecond;

    /// <summary>
    /// By how much does this location change the player's mood, per second?
    /// </summary>
    [Tooltip("By how much does this location change the player's mood, " + 
        "per second?")]
    public float MoodChangePerSecond;

    /// <summary>
    /// What color will this location change the mood ring to?
    /// </summary>
    [Tooltip("What color will this location change the mood ring to?")]
    public Color MoodColor = Color.white;
}

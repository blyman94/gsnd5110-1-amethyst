using UnityEngine;

/// <summary>
/// Represents a location on the map that influences the player's state.
/// </summary>
public class Location : MonoBehaviour
{
    /// <summary>
    /// Data to identify the location's effect on the player state.
    /// </summary>
    [Tooltip("Data to identify the location's effect on the player state.")]
    [SerializeField] private LocationData _locationData;

    /// <summary>
    /// Color representing the player's current mood.
    /// </summary>
    [Header("Player State")]
    [Tooltip("Color representing the player's current mood.")]
    [SerializeField] private ColorVariable _playerMoodColor;

    /// <summary>
    /// Float representing the player's current energy level.
    /// </summary>
    [Tooltip("Float representing the player's current energy level.")]
    [SerializeField] private FloatVariable _playerEnergy;

    /// <summary>
    /// Float representing the player's current evidence level.
    /// </summary>
    [Tooltip("Float representing the player's current evidence level.")]
    [SerializeField] private FloatVariable _playerEvidence;

    /// <summary>
    /// Float representing the player's current productivity level.
    /// </summary>
    [Tooltip("Float representing the player's current productivity level.")]
    [SerializeField] private FloatVariable _playerProductivity;
    
    /// <summary>
    /// Current mood color storage.
    /// </summary>
    private Color _currentMoodColor;

    /// <summary>
    /// Sets the current mood color to the current mood color of the player.
    /// </summary>
    public void InitializeCurrentMoodColor()
    {
        _currentMoodColor = _playerMoodColor.Value;
    }

    /// <summary>
    /// Update's the player state based on location data, should be called in a
    /// "OnTriggerStay2D" loop.
    /// </summary>
    public void UpdatePlayerState()
    {

        _playerEnergy.Value += _locationData.EnergyChangePerSecond * Time.deltaTime;
        _playerProductivity.Value += _locationData.ProductivityChangePerSecond * Time.deltaTime;
        _playerEvidence.Value += _locationData.EvidenceChangePerSecond * Time.deltaTime;

        _currentMoodColor = Color.Lerp(_currentMoodColor,
            _locationData.MoodColor,
            _locationData.MoodChangePerSecond * Time.deltaTime);
        _playerMoodColor.Value = _currentMoodColor;
    }
}

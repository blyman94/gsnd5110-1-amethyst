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
    /// Player State Data to update.
    /// </summary>
    [Tooltip("Player State Data to update.")]
    [SerializeField] private PlayerStateData _playerStateData;

    /// <summary>
    /// Current mood color storage.
    /// </summary>
    private Color _currentMoodColor;

    #region MonoBehaviourMethods
    private void Start()
    {
        _currentMoodColor = _playerStateData.MoodColor;
    }
    #endregion

    /// <summary>
    /// Update's the player state based on location data, should be called in a
    /// "OnTriggerStay2D" loop.
    /// </summary>
    public void UpdatePlayerState()
    {
        _playerStateData.Energy += _locationData.EnergyChangePerSecond * Time.deltaTime;
        _playerStateData.Productivity += _locationData.ProductivityChangePerSecond * Time.deltaTime;
        _playerStateData.Evidence += _locationData.ProductivityChangePerSecond * Time.deltaTime;

        _currentMoodColor = Color.Lerp(_currentMoodColor, _locationData.MoodColor, _locationData.MoodChangePerSecond * Time.deltaTime);
        _playerStateData.MoodColor = _currentMoodColor;
    }
}

using UnityEngine;

/// <summary>
/// Monitors the player state to see if a win or loss condition has been met.
/// </summary>
public class PlayerStateMonitor : MonoBehaviour
{
    /// <summary>
    /// Player's current energy level.
    /// </summary>
    [Tooltip("Player's current energy level.")]
    [SerializeField] private FloatVariable _playerEnergy;

    /// <summary>
    /// Player's current productivity level.
    /// </summary>
    [Tooltip("Player's current productivity level.")]
    [SerializeField] private FloatVariable _playerProductivity;

    /// <summary>
    /// Player's current evidence level.
    /// </summary>
    [Tooltip("Player's current evidence level.")]
    [SerializeField] private FloatVariable _playerEvidence;

    /// <summary>
    /// Event to raise if the player's productivity or energy falls to 0.
    /// </summary>
    [Tooltip("Event to raise if the player's productivity or energy falls to 0.")]
    [SerializeField] private GameEvent _gameOverEvent;

    /// <summary>
    /// Event to raise if the player's evidence reaches 1.
    /// </summary>
    [Tooltip("Event to raise if the player's evidence reaches 1.")]
    [SerializeField] private GameEvent _winGameEvent;

    #region MonoBehaviour Methods
    private void OnEnable()
    {
        _playerEnergy.VariableUpdated += CheckEnergy;
        _playerProductivity.VariableUpdated += CheckProductivity;
        _playerEvidence.VariableUpdated += CheckEvidence;
    }
    private void OnDisable()
    {
        _playerEnergy.VariableUpdated -= CheckEnergy;
        _playerProductivity.VariableUpdated -= CheckProductivity;
        _playerEvidence.VariableUpdated -= CheckEvidence;
    }
    #endregion

    /// <summary>
    /// Checks to see if the player's energy is less than or equal to 0. If so, 
    /// raises the game over event.
    /// </summary>
    private void CheckEnergy()
    {
        if (_playerEnergy.Value <= 0)
        {
            _gameOverEvent.Raise();
        }
    }

    /// <summary>
    /// Checks to see if the player's productivity is less than or equal to 0. 
    /// If so, raises the game over event.
    /// </summary>
    private void CheckProductivity()
    {
        if (_playerProductivity.Value <= 0)
        {
            _gameOverEvent.Raise();
        }
    }

    /// <summary>
    /// Checks to see if the player's evidence is greater than or equal to 1. If 
    /// so, raises the win game event.
    /// </summary>
    private void CheckEvidence()
    {
        if (_playerEvidence.Value >= 1)
        {
            _winGameEvent.Raise();
        }
    }
}

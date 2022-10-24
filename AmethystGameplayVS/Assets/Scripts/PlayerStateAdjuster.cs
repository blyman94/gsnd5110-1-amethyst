using UnityEngine;

/// <summary>
/// Applies natural behaviour of player state - that is, the baseline 
/// decreasing of the player's energy and productivity.
/// </summary>
public class PlayerStateAdjuster : MonoBehaviour
{
    /// <summary>
    /// Gameplay settings.
    /// </summary>
    [SerializeField] private GameplaySettings _gameplaySettings;

    /// <summary>
    /// Player's current energy level.
    /// </summary>
    [SerializeField] private FloatVariable _playerEnergy;

    /// <summary>
    /// Player's current productivity level.
    /// </summary>
    [SerializeField] private FloatVariable _playerProductivity;

    /// <summary>
    /// Player's current evidence level.
    /// </summary>
    [SerializeField] private FloatVariable _playerEvidence;

    #region MonoBehaviour Methods
    private void Awake()
    {
        _playerEnergy.Value = _gameplaySettings.StartingEnergy;
        _playerProductivity.Value = _gameplaySettings.StartingProductivity;
        _playerEvidence.Value = 0.0f;
    }
    private void Update()
    {
        _playerEnergy.Value -=
            Mathf.Abs(_gameplaySettings.NaturalEnergyLoss) * Time.deltaTime;
        _playerProductivity.Value -=
            Mathf.Abs(_gameplaySettings.NaturalProductivityLoss) * Time.deltaTime;
    }
    #endregion
}

using UnityEngine;

/// <summary>
/// Changes a SpriteRenderer's color to match the mood color of the player
/// state.
/// </summary>
public class SyncPlayerGraphicsColorToMood : MonoBehaviour
{
    /// <summary>
    /// Player state data driving the color change.
    /// </summary>
    [SerializeField] private PlayerStateData _playerStateData;

    /// <summary>
    /// Player state data driving the color change.
    /// </summary>
    [SerializeField] private SpriteRenderer _playerBodySpriteRenderer;

    #region MonoBehaviour Methods
    private void Update()
    {
        if (_playerStateData.MoodColor != _playerBodySpriteRenderer.color)
        {
            _playerBodySpriteRenderer.color = _playerStateData.MoodColor;
        }
    }
    #endregion
}

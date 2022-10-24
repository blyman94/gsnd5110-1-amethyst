using UnityEngine;

/// <summary>
/// Changes a SpriteRenderer's color to match the mood color of the player
/// state.
/// </summary>
public class SyncSpriteRendererColorToMood : MonoBehaviour
{
    /// <summary>
    /// Player state data driving the color change.
    /// </summary>
    [SerializeField] private PlayerStateData _playerStateData;

    /// <summary>
    /// Player state data driving the color change.
    /// </summary>
    [SerializeField] private SpriteRenderer _playerBodySpriteRenderer;

    /// <summary>
    /// Reference to the starting color of the graphics.
    /// </summary>
    private Color _startColor;

    #region MonoBehaviour Methods
    private void Start()
    {
        _startColor = _playerBodySpriteRenderer.color;
    }
    private void Update()
    {
        if (_playerStateData.MoodColor != _playerBodySpriteRenderer.color)
        {
            _playerBodySpriteRenderer.color = _playerStateData.MoodColor;
        }
    }
    private void OnDisable()
    {
        // Reset player color
        _playerBodySpriteRenderer.color = _startColor;
        _playerStateData.MoodColor = _startColor;
    }
    #endregion
}

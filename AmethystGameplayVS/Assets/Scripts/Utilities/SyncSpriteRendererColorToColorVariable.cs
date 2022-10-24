using UnityEngine;

/// <summary>
/// Changes a SpriteRenderer's color to match the mood color of the player
/// state.
/// </summary>
public class SyncSpriteRendererColorToColorVariable : MonoBehaviour
{
    /// <summary>
    /// ColorVariable driving the color change.
    /// </summary>
    [Tooltip("ColorVariable driving the color change.")]
    [SerializeField] private ColorVariable _colorVariable;

    /// <summary>
    /// Sprite renderer whose color will be synced.
    /// </summary>
    [Tooltip("Sprite renderer whose color will be synced.")]
    [SerializeField] private SpriteRenderer _spriteRenderer;

    /// <summary>
    /// Reference to the starting color of the graphics.
    /// </summary>
    private Color _startColor;

    #region MonoBehaviour Methods
    private void Start()
    {
        _startColor = _spriteRenderer.color;
    }
    private void Update()
    {
        if (_colorVariable.Value != _spriteRenderer.color)
        {
            _spriteRenderer.color = _colorVariable.Value;
        }
    }
    private void OnDisable()
    {
        // Reset player color
        _spriteRenderer.color = _startColor;
        _colorVariable.Value = _startColor;
    }
    #endregion
}

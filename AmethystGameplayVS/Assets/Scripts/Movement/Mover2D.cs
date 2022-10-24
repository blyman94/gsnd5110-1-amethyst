using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows for top-down 2D movement through Rigidbody2D physics.
/// </summary>
public class Mover2D : MonoBehaviour
{
    /// <summary>
    /// GameplaySettings containing movement parameters.
    /// </summary>
    [Header("Data")]
    [Tooltip("GameplaySettings containing movement parameters.")]
    [SerializeField] private GameplaySettings gameplaySettings;

    /// <summary>
    /// The Rigidbody2D to be controlled.
    /// </summary>
    [Header("Component References")]
    [Tooltip("The Rigidbody2D to be controlled.")]
    [SerializeField] private Rigidbody2D _rb2D;

    /// <summary>
    /// Current move input.
    /// </summary>
    public Vector2 MoveInput { get; set; }

    /// <summary>
    /// Speed the Mover2D is currently moving at.
    /// </summary>
    private Vector2 _currentVelocity;

    #region MonoBehaviour Methods
    private void FixedUpdate()
    {
        if (MoveInput.sqrMagnitude > 0.0f)
        {
            _currentVelocity = 
                new Vector2(Mathf.Lerp(_currentVelocity.x, 
                MoveInput.normalized.x * gameplaySettings.MoveSpeed, 
                gameplaySettings.AccelerationFactor),
                Mathf.Lerp(_currentVelocity.y, 
                MoveInput.normalized.y * gameplaySettings.MoveSpeed, 
                gameplaySettings.AccelerationFactor));
        }
        else
        {
            _currentVelocity = 
                new Vector2(Mathf.Lerp(_currentVelocity.x, 0.0f, 
                gameplaySettings.DecelerationFactor),
                Mathf.Lerp(_currentVelocity.y, 0.0f, 
                gameplaySettings.DecelerationFactor));
        }
        
        _rb2D.velocity = _currentVelocity;
    }
    #endregion
}

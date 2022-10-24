using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Syncs the rotation of an object to the velocity of a RigidBody2D.
/// </summary>
public class SyncRotationToVelocity : MonoBehaviour
{
    /// <summary>
    /// GameplaySettings containing movement parameters.
    /// </summary>
    [Header("Data")]
    [Tooltip("GameplaySettings containing movement parameters.")]
    [SerializeField] private GameplaySettings gameplaySettings;

    /// <summary>
    /// The Rigidbody2D driving rotation.
    /// </summary>
    [Header("Component References")]
    [Tooltip("The Rigidbody2D driving rotation.")]
    [SerializeField] private Rigidbody2D _rb2D;

    /// <summary>
    /// Speed the Mover2D is currently moving at.
    /// </summary>
    private Quaternion _currentRotation;

    #region MonoBehaviour Methods
    private void Update()
    {
        if (_rb2D.velocity.sqrMagnitude > 0.0f)
        {
            _currentRotation = Quaternion.Lerp(_currentRotation, 
                Quaternion.LookRotation(Vector3.forward, _rb2D.velocity), 
                gameplaySettings.RotationFactor);
        }
        
        transform.rotation = _currentRotation;
    }
    #endregion
}

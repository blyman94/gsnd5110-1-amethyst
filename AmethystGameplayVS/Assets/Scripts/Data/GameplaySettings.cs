using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains a vast array of parameters that will affect gameplay.
/// </summary>
[CreateAssetMenu]
public class GameplaySettings : ScriptableObject
{
    [Header("Player Movement")]
    [Tooltip("How fast can the player move?")]
    public float MoveSpeed = 5;

    [Tooltip("Amount by which speed is interpolated in the positive " + 
        "direction. Lower values make the player feel heavier, whereas " + 
        "higher values make the player feel lighter and more responsive.")]
    [Range(0.01f,1.0f)]
    public float AccelerationFactor = 0.05f;
    
    [Tooltip("Amount by which speed is interpolated in the negative " + 
        "direction. Lower values make the player feel heavier, whereas " + 
        "higher values make the player feel lighter and more responsive.")]
    [Range(0.01f,1.0f)]
    public float DecelerationFactor = 0.1f;

    [Tooltip("Amount by which rotation is interpolated . Lower values make " + 
        "the player feel heavier, whereas higher values make the player feel " +
        "lighter and more responsive.")]
    [Range(0.01f,1.0f)]
    public float RotationFactor = 0.05f;

    [Header("Meter Parameters")]
    /// <summary>
    /// How much energy does the player start off with?
    /// </summary>
    [Tooltip("How much energy does the player start off with?")]
    public float StartingEnergy = 1.0f;
    
    /// <summary>
    /// How much productivity does the player start off with?
    /// </summary>
    [Tooltip("How much productivity does the player start off with?")]
    public float StartingProductivity = 0.75f;

    /// <summary>
    /// How much energy does the player lose per second when not in any 
    /// location?
    /// </summary>
    [Tooltip("How much energy does the player lose per second when not in any" + 
        "location?")]
    public float NaturalEnergyLoss = 0.01f;

    /// <summary>
    /// How much productivity does the player lose per second when not in any 
    /// location?
    /// </summary>
    [Tooltip("How much productivity does the player lose per second when " + 
        "not in any location?")]
    public float NaturalProductivityLoss = 0.01f;
}

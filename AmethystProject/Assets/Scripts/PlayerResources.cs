using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerResources : ScriptableObject
{
    [Header("Home")]
    public bool HomeActive = false;
    public float HomeResource = 1.0f;
    public float HomeFillRate = 0.1f;
    public float HomeDrainRate = 0.1f;

    [Header("Work")]
    public bool WorkActive = false;
    public float WorkResource = 1.0f;
    public float WorkFillRate = 0.1f;
    public float WorkDrainRate = 0.1f;
}

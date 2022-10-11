using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerResources : ScriptableObject
{
    [Header("Home")]
    public bool PlayerInHome = false;
    public bool HomeActive = true;
    public float HomeResource = 1.0f;
    public float HomeFillRate = 0.1f;
    public float HomeDrainRate = 0.1f;

    [Header("Work")]
    public bool PlayerInWork = false;
    public bool WorkActive = false;
    public float WorkResource = 1.0f;
    public float WorkFillRate = 0.1f;
    public float WorkDrainRate = 0.1f;

    [Header("Diner")]
    public bool PlayerInDiner = false;
    public bool DinerActive = false;
    public float DinerResource = 1.0f;
    public float DinerFillRate = 0.1f;
    public float DinerDrainRate = 0.1f;

    [Header("Court")]
    public bool PlayerInCourt = false;
    public bool CourtActive = false;
    public float CourtResource = 1.0f;
    public float CourtFillRate = 0.1f;
    public float CourtDrainRate = 0.1f;

    [Header("Forest")]
    public bool PlayerInForest = false;
    public bool ForestActive = false;
    public float ForestResource = 1.0f;
    public float ForestFillRate = 0.1f;
    public float ForestDrainRate = 0.1f;

    [Header("Pond")]
    public bool PlayerInPond = false;
    public bool PondActive = false;
    public float PondResource = 1.0f;
    public float PondFillRate = 0.1f;
    public float PondDrainRate = 0.1f;

    [Header("Clerk")]
    public bool PlayerInClerk = false;
    public bool ClerkActive = false;
    public float ClerkResource = 1.0f;
    public float ClerkFillRate = 0.1f;
    public float ClerkDrainRate = 0.1f;

    [Header("Mill")]
    public bool PlayerInMill = false;
    public bool MillActive = false;
    public float MillResource = 1.0f;
    public float MillFillRate = 0.1f;
    public float MillDrainRate = 0.1f;
}

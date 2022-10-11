using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBinding : MonoBehaviour
{
    [SerializeField] private PlayerResources playerResources;
    [SerializeField] private BuildingType buildingType;
    [SerializeField] private Slider resourceSlider;

    #region MonoBehaviour Methods
    private void Update()
    {
        switch (buildingType)
        {
            case BuildingType.Home:
                resourceSlider.value = playerResources.HomeResource;
                break;
            case BuildingType.Work:
                resourceSlider.value = playerResources.WorkResource;
                break;
            case BuildingType.Diner:
                resourceSlider.value = playerResources.DinerResource;
                break;
            case BuildingType.Court:
                resourceSlider.value = playerResources.CourtResource;
                break;
            case BuildingType.Forest:
                resourceSlider.value = playerResources.ForestResource;
                break;
            case BuildingType.Pond:
                resourceSlider.value = playerResources.PondResource;
                break;
            case BuildingType.Clerk:
                resourceSlider.value = playerResources.ClerkResource;
                break;
            case BuildingType.Mill:
                resourceSlider.value = playerResources.MillResource;
                break;
            default:
                break;
        }
    }
    #endregion
}

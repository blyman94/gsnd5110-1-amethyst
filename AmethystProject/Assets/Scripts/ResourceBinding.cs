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
            default:
                break;
        }
    }
    #endregion
}

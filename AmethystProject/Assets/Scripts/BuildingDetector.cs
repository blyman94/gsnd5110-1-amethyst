using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDetector : MonoBehaviour
{
    public PlayerResources resources;

    #region MonoBehaviour Methods
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Building"))
        {
            Building building = other.GetComponent<Building>();

            switch (building.BuildingType)
            {
                case BuildingType.Home:
                    resources.HomeActive = true;
                    break;
                case BuildingType.Work:
                    resources.WorkActive = true;
                    break;
                default:
                    break;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Building"))
        {
            Building building = other.GetComponent<Building>();
            switch (building.BuildingType)
            {
                case BuildingType.Home:
                    resources.HomeActive = false;
                    break;
                case BuildingType.Work:
                    resources.WorkActive = false;
                    break;
                default:
                    break;
            }
        }
    }
    #endregion
}

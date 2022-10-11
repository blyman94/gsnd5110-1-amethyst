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
                    resources.PlayerInHome = true;
                    break;
                case BuildingType.Work:
                    resources.PlayerInWork = true;
                    break;
                case BuildingType.Diner:
                    resources.PlayerInDiner = true;
                    break;
                case BuildingType.Court:
                    resources.PlayerInCourt = true;
                    break;
                case BuildingType.Forest:
                    resources.PlayerInForest = true;
                    break;
                case BuildingType.Pond:
                    resources.PlayerInPond = true;
                    break;
                case BuildingType.Clerk:
                    resources.PlayerInClerk = true;
                    break;
                case BuildingType.Mill:
                    resources.PlayerInMill = true;
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
                    resources.PlayerInHome = false;
                    break;
                case BuildingType.Work:
                    resources.PlayerInWork = false;
                    break;
                case BuildingType.Diner:
                    resources.PlayerInDiner = false;
                    break;
                case BuildingType.Court:
                    resources.PlayerInCourt = false;
                    break;
                case BuildingType.Forest:
                    resources.PlayerInForest = false;
                    break;
                case BuildingType.Pond:
                    resources.PlayerInPond = false;
                    break;
                case BuildingType.Clerk:
                    resources.PlayerInClerk = false;
                    break;
                case BuildingType.Mill:
                    resources.PlayerInMill = false;
                    break;
                default:
                    break;
            }
        }
    }
    #endregion
}

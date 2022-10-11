using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public PlayerResources resources;
    public CanvasGroup gameOverGroup;
    public CanvasGroup WorkGroup;
    public CanvasGroup DinerGroup;
    public CanvasGroup CourtGroup;
    public CanvasGroup ForestGroup;
    public CanvasGroup PondGroup;
    public CanvasGroup ClerkGroup;
    public CanvasGroup MillGroup;
    public GameObject PlayerControlsObject;

    private float newBuildingTime = 5.0f;
    public float timeBetweenBuildings = 5.0f;
    private int newBuildingCounter = 0;

    #region MonoBehaviour Methods
    private void Start()
    {
        resources.PlayerInHome = false;
        resources.PlayerInWork = false;
        resources.PlayerInDiner = false;
        resources.PlayerInCourt = false;
        resources.PlayerInForest = false;
        resources.PlayerInPond = false;
        resources.PlayerInClerk = false;
        resources.PlayerInMill = false;

        resources.HomeActive = true;
        resources.WorkActive = false;
        resources.DinerActive = false;
        resources.CourtActive = false;
        resources.ForestActive = false;
        resources.PondActive = false;
        resources.ClerkActive = false;
        resources.MillActive = false;

        resources.HomeResource = 1.0f;
        resources.WorkResource = 1.0f;
        resources.DinerResource = 1.0f;
        resources.CourtResource = 1.0f;
        resources.ForestResource = 1.0f;
        resources.PondResource = 1.0f;
        resources.ClerkResource = 1.0f;
        resources.MillResource = 1.0f;

        newBuildingCounter = 0;
    }
    private void Update()
    {
        UpdateHomeResource();
        UpdateWorkResource();
        UpdateDinerResource();
        UpdateCourtResource();
        UpdateForestResource();
        UpdatePondResource();
        UpdateClerkResource();
        UpdateMillResource();

        // Check if game ends
        if (resources.HomeResource <= 0 ||
            resources.WorkResource <= 0 ||
            resources.DinerResource <= 0 ||
            resources.CourtResource <= 0 ||
            resources.ForestResource <= 0 ||
            resources.PondResource <= 0 ||
            resources.ClerkResource <= 0 ||
            resources.MillResource <= 0)
        {
            gameOverGroup.alpha = 1;
            gameOverGroup.blocksRaycasts = true;
            gameOverGroup.interactable = true;
            PlayerControlsObject.SetActive(false);
        }

        newBuildingTime -= Time.deltaTime;
        if (newBuildingTime <= 0.0f)
        {
            if (newBuildingCounter == 0)
            {
                WorkGroup.alpha = 1;
                resources.WorkActive = true;
                newBuildingCounter++;
            }
            else if (newBuildingCounter == 1)
            {
                DinerGroup.alpha = 1;
                resources.DinerActive = true;
                newBuildingCounter++;
            }
            else if (newBuildingCounter == 2)
            {
                CourtGroup.alpha = 1;
                resources.CourtActive = true;
                newBuildingCounter++;
            }
            else if (newBuildingCounter == 3)
            {
                ForestGroup.alpha = 1;
                resources.ForestActive = true;
                newBuildingCounter++;
            }
            else if (newBuildingCounter == 4)
            {
                PondGroup.alpha = 1;
                resources.PondActive = true;
                newBuildingCounter++;
            }
            else if (newBuildingCounter == 5)
            {
                ClerkGroup.alpha = 1;
                resources.ClerkActive = true;
                newBuildingCounter++;
            }
            else if (newBuildingCounter == 6)
            {
                MillGroup.alpha = 1;
                resources.MillActive = true;
                newBuildingCounter++;
            }

            newBuildingTime = timeBetweenBuildings;
        }
    }
    #endregion

    private void UpdateHomeResource()
    {
        if (resources.HomeActive)
        {
            if (resources.PlayerInHome)
            {
                if (resources.HomeResource >= 1.0f)
                {
                    resources.HomeResource = 1.0f;
                }
                else
                {
                    resources.HomeResource += resources.HomeFillRate * Time.deltaTime;
                }
            }
            else
            {
                if (resources.HomeResource <= 0.0f)
                {
                    resources.HomeResource = 0.0f;
                }
                else
                {
                    resources.HomeResource -= resources.HomeDrainRate * Time.deltaTime;
                }
            }
        }
    }

    private void UpdateWorkResource()
    {
        if (resources.WorkActive)
        {
            if (resources.PlayerInWork)
            {
                if (resources.WorkResource >= 1.0f)
                {
                    resources.WorkResource = 1.0f;
                }
                else
                {
                    resources.WorkResource += resources.WorkFillRate * Time.deltaTime;
                }
            }
            else
            {
                if (resources.WorkResource <= 0.0f)
                {
                    resources.WorkResource = 0.0f;
                }
                else
                {
                    resources.WorkResource -= resources.WorkDrainRate * Time.deltaTime;
                }
            }
        }
    }

    private void UpdateDinerResource()
    {
        if (resources.DinerActive)
        {
            if (resources.PlayerInDiner)
            {
                if (resources.DinerResource >= 1.0f)
                {
                    resources.DinerResource = 1.0f;
                }
                else
                {
                    resources.DinerResource += resources.DinerFillRate * Time.deltaTime;
                }
            }
            else
            {
                if (resources.DinerResource <= 0.0f)
                {
                    resources.DinerResource = 0.0f;
                }
                else
                {
                    resources.DinerResource -= resources.DinerDrainRate * Time.deltaTime;
                }
            }
        }
    }

    private void UpdateCourtResource()
    {
        if (resources.CourtActive)
        {
            if (resources.PlayerInCourt)
            {
                if (resources.CourtResource >= 1.0f)
                {
                    resources.CourtResource = 1.0f;
                }
                else
                {
                    resources.CourtResource += resources.CourtFillRate * Time.deltaTime;
                }
            }
            else
            {
                if (resources.CourtResource <= 0.0f)
                {
                    resources.CourtResource = 0.0f;
                }
                else
                {
                    resources.CourtResource -= resources.CourtDrainRate * Time.deltaTime;
                }
            }
        }
    }

    private void UpdateForestResource()
    {
        if (resources.ForestActive)
        {
            if (resources.PlayerInForest)
            {
                if (resources.ForestResource >= 1.0f)
                {
                    resources.ForestResource = 1.0f;
                }
                else
                {
                    resources.ForestResource += resources.ForestFillRate * Time.deltaTime;
                }
            }
            else
            {
                if (resources.ForestResource <= 0.0f)
                {
                    resources.ForestResource = 0.0f;
                }
                else
                {
                    resources.ForestResource -= resources.ForestDrainRate * Time.deltaTime;
                }
            }
        }
    }

    private void UpdatePondResource()
    {
        if (resources.PondActive)
        {
            if (resources.PlayerInPond)
            {
                if (resources.PondResource >= 1.0f)
                {
                    resources.PondResource = 1.0f;
                }
                else
                {
                    resources.PondResource += resources.PondFillRate * Time.deltaTime;
                }
            }
            else
            {
                if (resources.PondResource <= 0.0f)
                {
                    resources.PondResource = 0.0f;
                }
                else
                {
                    resources.PondResource -= resources.PondDrainRate * Time.deltaTime;
                }
            }
        }
    }

    private void UpdateClerkResource()
    {
        if (resources.ClerkActive)
        {
            if (resources.PlayerInClerk)
            {
                if (resources.ClerkResource >= 1.0f)
                {
                    resources.ClerkResource = 1.0f;
                }
                else
                {
                    resources.ClerkResource += resources.ClerkFillRate * Time.deltaTime;
                }
            }
            else
            {
                if (resources.ClerkResource <= 0.0f)
                {
                    resources.ClerkResource = 0.0f;
                }
                else
                {
                    resources.ClerkResource -= resources.ClerkDrainRate * Time.deltaTime;
                }
            }
        }
    }

    private void UpdateMillResource()
    {
        if (resources.MillActive)
        {
            if (resources.PlayerInMill)
            {
                if (resources.MillResource >= 1.0f)
                {
                    resources.MillResource = 1.0f;
                }
                else
                {
                    resources.MillResource += resources.MillFillRate * Time.deltaTime;
                }
            }
            else
            {
                if (resources.MillResource <= 0.0f)
                {
                    resources.MillResource = 0.0f;
                }
                else
                {
                    resources.MillResource -= resources.MillDrainRate * Time.deltaTime;
                }
            }
        }
    }
}

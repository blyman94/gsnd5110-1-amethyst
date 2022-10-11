using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public PlayerResources resources;

    #region MonoBehaviour Methods
    private void Start()
    {
        resources.HomeActive = false;
        resources.WorkActive = false;
    }
    private void Update()
    {
        UpdateHomeResource();
        UpdateWorkResource();
    }
    #endregion

    private void UpdateHomeResource()
    {
        if (resources.HomeActive)
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

    private void UpdateWorkResource()
    {
        if (resources.WorkActive)
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

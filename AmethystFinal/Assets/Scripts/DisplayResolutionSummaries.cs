using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayResolutionSummaries : MonoBehaviour
{
    [SerializeField] private ListOfStringsVariable _resolutionSummaries;
    [SerializeField] private GameObject _resolutionTextPrefab;
    [SerializeField] private GameObject _ledRevolutionTextPrefab;
    [SerializeField] private Transform _resolutionTextParent;
    
    #region MonoBehaviour Methods
    private void OnEnable()
    {
        _resolutionSummaries.VariableUpdated += UpdateResolutionsDisplay;
    }

    private void Start()
    {
        UpdateResolutionsDisplay();
    }
    private void OnDisable()
    {
        _resolutionSummaries.VariableUpdated -= UpdateResolutionsDisplay;
    }
    #endregion

    private void UpdateResolutionsDisplay()
    {
        for(int i = _resolutionTextParent.childCount - 1; i >= 0; i--)
        {
            Destroy(_resolutionTextParent.GetChild(i).gameObject);
        }

        foreach (string resolutionString in _resolutionSummaries.Value)
        {
            GameObject resolutionObject = Instantiate(_resolutionTextPrefab,
                _resolutionTextParent);
            resolutionObject.GetComponent<TextMeshProUGUI>().text =
                resolutionString;
        }
        
        Instantiate(_ledRevolutionTextPrefab, _resolutionTextParent);
    }
}

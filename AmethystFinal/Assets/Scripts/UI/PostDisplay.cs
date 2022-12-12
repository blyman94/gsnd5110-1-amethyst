using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostDisplay : MonoBehaviour
{
    [SerializeField] private GameObject[] _storyDisplayTransforms;
    
    #region MonoBehaviour Methods
    private void Start()
    {
        HideStoryDisplayTransforms();
    }
    #endregion

    public void HideStoryDisplayTransforms()
    {
        foreach (GameObject storyDisplayObject in _storyDisplayTransforms)
        {
            storyDisplayObject.SetActive(false);
        }
    }
    
    public void ShowStoryDisplayTransforms()
    {
        foreach (GameObject storyDisplayObject in _storyDisplayTransforms)
        {
            storyDisplayObject.SetActive(true);
        }
    }
}

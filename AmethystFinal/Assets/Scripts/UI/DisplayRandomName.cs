using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayRandomName : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _randomNameText;

    private void Start()
    {
        DisplayName();
    }

    public void DisplayName()
    {
        _randomNameText.text = RandomNameGenerator.GetRandomName();
    }
}

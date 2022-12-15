using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSpeedHandler : MonoBehaviour
{
    public TextMeshProUGUI _speedButtonText;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void ChangeGameSpeed()
    {
        if(Time.timeScale == 1.0f)
        {
            Time.timeScale = 2.0f;
            _speedButtonText.text = "2x";
        }
        else if(Time.timeScale == 2.0f)
        {
            Time.timeScale = 1.0f;
            _speedButtonText.text = "1x";
        }
    }
}

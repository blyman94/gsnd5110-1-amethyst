using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private UnityEvent _onStartResponse;
    private void Start()
    {
        _onStartResponse?.Invoke();
    }
}

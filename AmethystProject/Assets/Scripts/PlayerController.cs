using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Mover2D playerMover;
    [SerializeField] private CanvasGroup resourceGroup;

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.performed) // Input.GetKey from old input system
        {
            playerMover.Move(context.ReadValue<Vector2>());
        }
        else
        {
            playerMover.Move(Vector2.zero);
        }
    }

    public void OnToggleUIInput(InputAction.CallbackContext context)
    {
        if (context.started) // Input.GetKeyDown from old input system
        {
            resourceGroup.alpha = 1;
        }
        if (context.canceled) // Input.GetKeyUp from old input system
        {
            resourceGroup.alpha = 0;
        }
    }
}

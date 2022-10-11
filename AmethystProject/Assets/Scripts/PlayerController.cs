using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Mover2D playerMover;

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerMover.Move(context.ReadValue<Vector2>());
        }
        else
        {
            playerMover.Move(Vector2.zero);
        }
    }
}

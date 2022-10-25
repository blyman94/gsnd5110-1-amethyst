using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Mover2D playerMover2D;
    [SerializeField] private NPCInteractor playerNPCInteractor;

    public void OnActivateInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerNPCInteractor.Activate();
        }
    }

    /// <summary>
    /// Changes the Player's Mover2D component's MoveInput value based on input.
    /// </summary>
    /// <param name="context">Callback context data for the Move input.</param>
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 input = context.ReadValue<Vector2>();
            playerMover2D.MoveInput = input;
        }
        else
        {
            playerMover2D.MoveInput = Vector2.zero;
        }
    }
}

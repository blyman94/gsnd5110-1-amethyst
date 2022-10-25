using UnityEngine;

/// <summary>
/// Allows the player to interact with NPCs.
/// </summary>
public class NPCInteractor : MonoBehaviour
{
    /// <summary>
    /// Color of the gizmo depicting this interactor's sensor when active.
    /// </summary>
    [Tooltip("Color of the gizmo depicting this sensor when active.")]
    [SerializeField] private Color _activeColor = Color.white;

    /// <summary>
    /// NPCData that represents the current, active NPC.
    /// </summary>
    [Tooltip("NPCData that represents the current, active NPC.")]
    [SerializeField] private NPCDataVariable _currentActiveNPCDataVariable;

    /// <summary>
    /// Event fired at the start of dialogue.
    /// </summary>
    [Tooltip("Event fired at the start of dialogue.")]
    [SerializeField] private GameEvent _dialogueStartEvent;

    /// <summary>
    /// Color of the gizmo depicting this interactor's sensor when inactive.
    /// </summary>
    [Tooltip("Color of the gizmo depicting this sensor when inactive.")]
    [SerializeField] private Color _inactiveColor = Color.white;

    /// <summary>
    /// Which layer(s) should this interactor's sensor detect?
    /// </summary>
    [Tooltip("Which layer(s) should this sensor detect?")]
    [SerializeField] private LayerMask _layerToSense;

    /// <summary>
    /// Size of the interactor's sensor.
    /// </summary>
    [Tooltip("Size of the sensor.")]
    [SerializeField] private Vector2 _squareSize;

    /// <summary>
    /// Collider of the NPC this interactor's sensor is currently detecting.
    /// </summary>
    private Collider2D _currentDetectedCollider;

    #region MonoBehaviour Methods
    private void FixedUpdate()
    {
        // Detect collider
        Collider2D potentialCurrentCollider = Physics2D.OverlapBox(transform.position,
            _squareSize, 0.0f, _layerToSense);

        // Check if the collider has the correct tag
        if (potentialCurrentCollider != null &&
            potentialCurrentCollider.CompareTag("NPC"))
        {

            _currentDetectedCollider = potentialCurrentCollider;
        }
        else
        {
            _currentDetectedCollider = null;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = _currentDetectedCollider == null ?
            _inactiveColor : _activeColor;
        Gizmos.DrawCube(transform.position, _squareSize);
    }
    #endregion

    /// <summary>
    /// Activates the detected NPC by invoking a GameEvent to start the dialogue
    /// sequence.
    /// </summary>
    public void Activate()
    {
        if (_currentDetectedCollider != null)
        {
            NPCData currentNPCData =
            _currentDetectedCollider.GetComponent<NPC>().NPCData;
            _currentActiveNPCDataVariable.Value = currentNPCData;
            _dialogueStartEvent.Raise();
        }
        // else: Do nothing! If we don't have a collider detected, we don't want
        // anything to happen.
    }
}

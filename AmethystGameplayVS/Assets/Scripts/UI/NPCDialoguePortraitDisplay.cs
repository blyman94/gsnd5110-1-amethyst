using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Responsible for updating the NPC Dialogue UI based on which NPC is currently
/// active.
/// </summary>
public class NPCDialoguePortraitDisplay : MonoBehaviour
{
    /// <summary>
    /// UI Image to display the NPC's portrait.
    /// </summary>
    [Tooltip("UI Image to display the NPC's portrait.")]
    [SerializeField] private Image _npcPortraitImage;

    /// <summary>
    /// Text object to store the NPC's name.
    /// </summary>
    [Tooltip("Text object to store the NPC's name.")]
    [SerializeField] private TextMeshProUGUI _npcNameText;

    /// <summary>
    /// NPCData that represents the current, active NPC.
    /// </summary>
    [Tooltip("NPCData that represents the current, active NPC.")]
    [SerializeField] private NPCDataVariable _currentActiveNPCData;

    public void UpdateDisplay()
    {
        _npcNameText.text = _currentActiveNPCData.Value.Name;
        _npcPortraitImage.sprite = _currentActiveNPCData.Value.PortraitSprite;
    }
}

using TMPro;
using UnityEngine;

public class NPCDialogueDriver : MonoBehaviour
{
    /// <summary>
    /// NPCData that represents the current, active NPC.
    /// </summary>
    [Tooltip("NPCData that represents the current, active NPC.")]
    [SerializeField] private NPCDataVariable _currentActiveNPCDataVariable;

    /// <summary>
    /// Text object to store the NPC's dialogue.
    /// </summary>
    [Tooltip("Text object to store the NPC's dialogue.")]
    [SerializeField] private TextMeshProUGUI _npcDialogueText;

    public void StartDialogue()
    {
        _npcDialogueText.text =
            _currentActiveNPCDataVariable.Value.DialogueSequence.StartDialogueString.Value;
    }

    public void EvalutateDialogueCondition()
    {
        DialogueCondition dialogueCondition =
            _currentActiveNPCDataVariable.Value.DialogueSequence.DialogueCondition;

        bool conditionMet = dialogueCondition.EvaluateCondition();

        if (conditionMet)
        {
            _npcDialogueText.text = dialogueCondition.TrueString.Value;
        }
        else
        {
            _npcDialogueText.text = dialogueCondition.FalseString.Value;
        }
    }
}

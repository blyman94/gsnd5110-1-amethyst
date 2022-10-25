using System.Collections.Generic;
using UnityEngine;

public class DialogueRewardResetter : MonoBehaviour
{
    public List<DialogueCondition> conditionsToReset;

    private void Awake()
    {
        foreach (DialogueCondition condition in conditionsToReset)
        {
            condition.RewardGiven = false;
        }
    }
}

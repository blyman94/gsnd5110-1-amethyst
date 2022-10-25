using UnityEngine;

/// <summary>
/// Represents a choice made by the NPC in dialogue based on the player's state.
/// </summary>
[CreateAssetMenu]
public class DialogueCondition : ScriptableObject
{
    /// <summary>
    /// What type of condition should this be?
    /// </summary>
    [Tooltip("What type of condition should this be?")]
    public DialogueConditionType Type;

    /// <summary>
    /// Player's current energy level.
    /// </summary>
    [Tooltip("Player's current energy level.")]
    public FloatVariable PlayerEnergy;

    /// <summary>
    /// The target energy level for this condition to be true.
    /// </summary>
    [Tooltip("The target energy level for this condition to be true.")]
    public float TargetEnergyLevel;

    /// <summary>
    /// How much more or less energy can this player have and still meet the 
    /// condition?
    /// </summary>
    [Tooltip("How much more or less energy can this player have and " +
        "still meet the condition?")]
    public float TargetEnergyTolerance;

    /// <summary>
    /// Player's current productivity level.
    /// </summary>
    [Tooltip("Player's current productivity level.")]
    public FloatVariable PlayerProductivity;

    /// <summary>
    /// The target productivity level for this condition to be true.
    /// </summary>
    [Tooltip("The target productivity level for this condition to be true.")]
    public float TargetProductivityLevel;

    /// <summary>
    /// How much more or less productivity can this player have and still meet 
    /// the condition?
    /// </summary>
    [Tooltip("How much more or less productivity can this player have and " +
        "still meet the condition?")]
    public float TargetProductivityTolerance;

    /// <summary>
    /// Player's current evidence level.
    /// </summary>
    [Tooltip("Player's current evidence level.")]
    public FloatVariable PlayerEvidence;

    /// <summary>
    /// The target evidence level for this condition to be true.
    /// </summary>
    [Tooltip("The target evidence level for this condition to be true.")]
    public float TargetEvidenceLevel;

    /// <summary>
    /// How much more or less evidence can this player have and still meet 
    /// the condition?
    /// </summary>
    [Tooltip("How much more or less evidence can this player have and " +
        "still meet the condition?")]
    public float TargetEvidenceTolerance;

    /// <summary>
    /// Player's current mood color.
    /// </summary>
    [Tooltip("Player's current mood color.")]
    public ColorVariable PlayerMoodColor;

    /// <summary>
    /// The target mood color for this condition to be true.
    /// </summary>
    [Tooltip("The target mood color for this condition to be true.")]
    public Color TargetMoodColor = Color.white;

    /// <summary>
    /// How much more or less hue can this player's mood color have and still 
    /// meet the condition?
    /// </summary>
    [Tooltip("How much more or less hue can this player have and " +
        "still meet the condition?")]
    public float TargetMoodColorHueTolerance;

    /// <summary>
    /// DialogueString to use if the condition is met.
    /// </summary>
    [Tooltip("DialogueString to use if the condition is met.")]
    public DialogueString TrueString;

    /// <summary>
    /// DialogueString to use if the condition is not met.
    /// </summary>
    [Tooltip("DialogueString to use if the condition is not met.")]
    public DialogueString FalseString;

    /// <summary>
    /// How much of a reward does the player get for meeting this condition?
    /// </summary>
    [Tooltip("How much of a reward does the player get for meeting " +
        "this condition?")]
    public float EvidenceReward;

    /// <summary>
    /// Hase the player already received this reward?
    /// </summary>
    public bool RewardGiven { get; set; } = false;

    /// <summary>
    /// Does the player meet this condition?
    /// </summary>
    /// <returns>Bool representing whether the player meets the 
    /// condition.</returns>
    public bool EvaluateCondition()
    {
        switch (Type)
        {
            case (DialogueConditionType.Energy):
                return TestEnergyCondition();
            case (DialogueConditionType.Productivity):
                return TestProductivityCondition();
            case (DialogueConditionType.Evidence):
                return TestEvidenceCondition();
            case (DialogueConditionType.Mood):
                return TestMoodCondition();
            default:
                Debug.LogError("WARNING: DialogueConditionType not " +
                        "recognized by DialogueCondition.cs.");
                return false;
        }
    }

    private bool TestMoodCondition()
    {
        // Get target hue from selected color
        Color.RGBToHSV(TargetMoodColor, out float targetH,
            out float targetS, out float targetV);

        // Get player mood hue from PlayerMood
        Color.RGBToHSV(PlayerMoodColor.Value, out float currentH,
            out float currentS, out float currentV);

        float hueMin = targetH - TargetMoodColorHueTolerance;
        float hueMax = targetH + TargetMoodColorHueTolerance;

        if (currentH >= hueMin && currentH <= hueMax && !RewardGiven)
        {
            RewardGiven = true;
            PlayerEvidence.Value += EvidenceReward;
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool TestEvidenceCondition()
    {
        float evidenceMin = TargetEvidenceLevel -
                            TargetEvidenceTolerance;
        float evidenceMax = TargetEvidenceLevel +
            TargetEvidenceTolerance;
        if (PlayerEvidence.Value >= evidenceMin &&
            PlayerEvidence.Value <= evidenceMax && 
            !RewardGiven)
        {
            RewardGiven = true;
            PlayerEvidence.Value += EvidenceReward;
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool TestProductivityCondition()
    {
        float productivityMin = TargetProductivityLevel -
                            TargetProductivityTolerance;
        float productivityMax = TargetProductivityLevel +
            TargetProductivityTolerance;
        if (PlayerProductivity.Value >= productivityMin &&
            PlayerProductivity.Value <= productivityMax && 
            !RewardGiven)
        {
            RewardGiven = true;
            PlayerEvidence.Value += EvidenceReward;
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool TestEnergyCondition()
    {
        float energyMin = TargetEnergyLevel - TargetEnergyTolerance;
        float energyMax = TargetEnergyLevel + TargetEnergyTolerance;
        if (PlayerEnergy.Value >= energyMin &&
            PlayerEnergy.Value <= energyMax && 
            !RewardGiven)
        {
            RewardGiven = true;
            PlayerEvidence.Value += EvidenceReward;
            return true;
        }
        else
        {
            return false;
        }
    }
}

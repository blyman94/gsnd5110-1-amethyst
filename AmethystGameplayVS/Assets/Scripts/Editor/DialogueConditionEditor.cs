using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Custom editor for the DialogueCondition class.
/// </summary>
[CustomEditor(typeof(DialogueCondition))]
[CanEditMultipleObjects]
public class DialogueConditionEditor : Editor
{
    private SerializedProperty _typeProperty;

    // Energy
    private SerializedProperty _playerEnergyProperty;
    private SerializedProperty _targetEnergyLevelProperty;
    private SerializedProperty _targetEnergyToleranceProperty;

    // Productivity
    private SerializedProperty _playerProductivityProperty;
    private SerializedProperty _targetProductivityLevelProperty;
    private SerializedProperty _targetProductivityToleranceProperty;

    // Evidence
    private SerializedProperty _playerEvidenceProperty;
    private SerializedProperty _targetEvidenceLevelProperty;
    private SerializedProperty _targetEvidenceToleranceProperty;

    // Mood
    private SerializedProperty _playerMoodColorProperty;
    private SerializedProperty _targetMoodColorProperty;
    private SerializedProperty _targetMoodColorHueToleranceProperty;

    // Resulting DialogueStrings
    private SerializedProperty _trueStringProperty;
    private SerializedProperty _falseStringProperty;

    #region Editor Methods
    void OnEnable()
    {
        _typeProperty = serializedObject.FindProperty("Type");

        // Energy
        _playerEnergyProperty = serializedObject.FindProperty("PlayerEnergy");
        _targetEnergyLevelProperty = serializedObject.FindProperty("TargetEnergyLevel");
        _targetEnergyToleranceProperty = serializedObject.FindProperty("TargetEnergyTolerance");

        // Productivity
        _playerProductivityProperty = serializedObject.FindProperty("PlayerProductivity");
        _targetProductivityLevelProperty = serializedObject.FindProperty("TargetProductivityLevel");
        _targetProductivityToleranceProperty = serializedObject.FindProperty("TargetProductivityTolerance");

        // Evidence
        _playerEvidenceProperty = serializedObject.FindProperty("PlayerEvidence");
        _targetEvidenceLevelProperty = serializedObject.FindProperty("TargetEvidenceLevel");
        _targetEvidenceToleranceProperty = serializedObject.FindProperty("TargetEvidenceTolerance");

        // Mood
        _playerMoodColorProperty = serializedObject.FindProperty("PlayerMoodColor");
        _targetMoodColorProperty = serializedObject.FindProperty("TargetMoodColor");
        _targetMoodColorHueToleranceProperty = serializedObject.FindProperty("TargetMoodColorHueTolerance");

        // Resulting DialogueStrings
        _trueStringProperty = serializedObject.FindProperty("TrueString");
        _falseStringProperty = serializedObject.FindProperty("FalseString");
    }

    public override void OnInspectorGUI()
    {

        using (new EditorGUI.DisabledScope(true))
            EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject((ScriptableObject)target), GetType(), false);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Condition Parameters", 
            EditorStyles.boldLabel);

        EditorGUILayout.PropertyField(_typeProperty);

        switch (_typeProperty.intValue)
        {
            case((int)DialogueConditionType.Energy):
                EditorGUILayout.PropertyField(_playerEnergyProperty);
                EditorGUILayout.PropertyField(_targetEnergyLevelProperty);
                EditorGUILayout.PropertyField(_targetEnergyToleranceProperty);
                break;
            case((int)DialogueConditionType.Productivity):
                EditorGUILayout.PropertyField(_playerProductivityProperty);
                EditorGUILayout.PropertyField(_targetProductivityLevelProperty);
                EditorGUILayout.PropertyField(_targetProductivityToleranceProperty);
                break;
            case((int)DialogueConditionType.Evidence):
                EditorGUILayout.PropertyField(_playerEvidenceProperty);
                EditorGUILayout.PropertyField(_targetEvidenceLevelProperty);
                EditorGUILayout.PropertyField(_targetEvidenceToleranceProperty);
                break;
            case((int)DialogueConditionType.Mood):
                EditorGUILayout.PropertyField(_playerMoodColorProperty);
                EditorGUILayout.PropertyField(_targetMoodColorProperty);
                EditorGUILayout.PropertyField(_targetMoodColorHueToleranceProperty);
                break;
            default:
                Debug.LogError("WARNING: DialogueConditionType not " + 
                    "recognized by DialogueConditionEditor.cs.");
                break;
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Resulting DialogueStrings", 
            EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_trueStringProperty);
        EditorGUILayout.PropertyField(_falseStringProperty);
        
        serializedObject.ApplyModifiedProperties();
    }
    #endregion
}

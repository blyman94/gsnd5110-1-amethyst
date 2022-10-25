using UnityEngine;
using UnityEditor;

/// <summary>
/// Custom editor for the CanvasGroupRevealer class.
/// </summary>
[CustomEditor(typeof(CanvasGroupRevealer))]
[CanEditMultipleObjects]
public class CanvasGroupRevealerEditor : Editor
{
    private SerializedProperty _startHiddenProperty;
    private SerializedProperty _canvasFadeInProperty;
    private SerializedProperty _canvasFadeOutProperty;
    private SerializedProperty _fadeTimeProperty;
    private SerializedProperty _fadeCurveProperty;
    private SerializedProperty _shownAlphaProperty;
    private SerializedProperty _shownBlockRaycastProperty;
    private SerializedProperty _shownInteractableProperty;

    private void OnEnable()
    {
        _canvasFadeInProperty = serializedObject.FindProperty("_canvasFadeIn");
        _canvasFadeOutProperty = serializedObject.FindProperty("_canvasFadeOut");
        _fadeTimeProperty = serializedObject.FindProperty("_fadeTime");
        _fadeCurveProperty = serializedObject.FindProperty("_fadeCurve");
        _shownAlphaProperty = serializedObject.FindProperty("_shownAlpha");
        _shownBlockRaycastProperty = serializedObject.FindProperty("_shownBlockRaycast");
        _shownInteractableProperty = serializedObject.FindProperty("_shownInteractable");
        _startHiddenProperty = serializedObject.FindProperty("_startHidden");
    }

    public override void OnInspectorGUI()
    {
        var canvasGroupRevealer = target as CanvasGroupRevealer;

        // Draw the Unity-standard script field atop the inspector.
        using (new EditorGUI.DisabledScope(true))
            EditorGUILayout.ObjectField("Script",
            MonoScript.FromMonoBehaviour((MonoBehaviour)target),
            GetType(), false);

        EditorGUILayout.PropertyField(_startHiddenProperty);

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Fade Behaviour [DO NOT USE]", 
            EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_canvasFadeInProperty);
        EditorGUILayout.PropertyField(_canvasFadeOutProperty);

        if (_canvasFadeInProperty.boolValue ||
            _canvasFadeOutProperty.boolValue)
        {
            EditorGUILayout.PropertyField(_fadeTimeProperty);
            EditorGUILayout.PropertyField(_fadeCurveProperty);
        }

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Shown State Properties",
            EditorStyles.boldLabel);

        EditorGUILayout.PropertyField(_shownAlphaProperty);
        EditorGUILayout.PropertyField(_shownBlockRaycastProperty);
        EditorGUILayout.PropertyField(_shownInteractableProperty);

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Testing", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("While in Play Mode, use these buttons " + 
            "to test show and hide behaviour.");

        if (GUILayout.Button("Show"))
        {
            if (Application.isPlaying)
            {
                canvasGroupRevealer.ShowGroup();
            }
        }

        if (GUILayout.Button("Hide"))
        {
            if (Application.isPlaying)
            {
                canvasGroupRevealer.HideGroup();
            }
        }

        serializedObject.ApplyModifiedProperties();
    }
}
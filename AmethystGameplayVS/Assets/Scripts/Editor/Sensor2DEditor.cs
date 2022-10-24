using UnityEngine;
using UnityEditor;

/// <summary>
/// Custom editor for the Sensor2D class.
/// </summary>
[CustomEditor(typeof(Sensor2D))]
[CanEditMultipleObjects]
public class Sensor2DEditor : Editor
{
    private SerializedProperty _sensorShapeProperty;
    private SerializedProperty _sensorSenseTagProperty;
    private SerializedProperty _sensorRadiusProperty;
    private SerializedProperty _sensorSquareSizeProperty;
    private SerializedProperty _sensorLayerToSenseProperty;
    private SerializedProperty _sensorTagToSenseProperty;
    private SerializedProperty _sensorActiveColorProperty;
    private SerializedProperty _sensorInactiveColorProperty;
    private SerializedProperty _sensorActiveProperty;

    /// <summary>
    /// Should info be displayed in the editor?
    /// </summary>
    private static bool showInfo = true;

    void OnEnable()
    {
        _sensorShapeProperty = serializedObject.FindProperty("_sensorShape");
        _sensorSenseTagProperty = serializedObject.FindProperty("_senseTag");
        _sensorRadiusProperty = serializedObject.FindProperty("_radius");
        _sensorSquareSizeProperty = serializedObject.FindProperty("_squareSize");
        _sensorLayerToSenseProperty = serializedObject.FindProperty("_layerToSense");
        _sensorTagToSenseProperty = serializedObject.FindProperty("_tagToSense");
        _sensorActiveColorProperty = serializedObject.FindProperty("_activeColor");
        _sensorActiveProperty = serializedObject.FindProperty("_active");
        _sensorInactiveColorProperty = serializedObject.FindProperty("_inactiveColor");
    }

    public override void OnInspectorGUI()
    {

        using (new EditorGUI.DisabledScope(true))
            EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((MonoBehaviour)target), GetType(), false);

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Geometry", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_sensorShapeProperty);

        switch (_sensorShapeProperty.intValue)
        {
            case ((int)SensorShape.Circle):
                EditorGUILayout.PropertyField(_sensorRadiusProperty);
                break;
            case ((int)SensorShape.Square):
                EditorGUILayout.PropertyField(_sensorSquareSizeProperty);
                break;
            default:
                break;
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("What To Sense", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_sensorLayerToSenseProperty);
        EditorGUILayout.PropertyField(_sensorSenseTagProperty);

        if (_sensorSenseTagProperty.boolValue)
        {
            EditorGUILayout.PropertyField(_sensorTagToSenseProperty);
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Colors", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_sensorActiveColorProperty);
        EditorGUILayout.PropertyField(_sensorInactiveColorProperty);

        EditorGUILayout.Space();
        showInfo = EditorGUILayout.Foldout(showInfo, "Info");
        if (showInfo)
        {
            using (new EditorGUI.DisabledScope(true))
                EditorGUILayout.PropertyField(_sensorActiveProperty);
        }

        serializedObject.ApplyModifiedProperties();
    }
}

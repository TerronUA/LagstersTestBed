using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(GravityManager))]
public class GravityManagerEditor : Editor
{
    GravityManager _target;
    SerializedProperty activeItemIndex;
    SerializedProperty activeItem;

    void Awake()
    {
        _target = target as GravityManager;
        activeItemIndex = serializedObject.FindProperty("activeIndex");
        activeItem = serializedObject.FindProperty("activePoint");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        base.OnInspectorGUI();

        GUILayout.Label("Gravity Item Creation");
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Add"))
        {
            _target.activeIndex = _target.AddPoint();
            SceneView.RepaintAll();
        }
        if (GUILayout.Button("Delete"))
        {
            _target.DeletePoint();
            SceneView.RepaintAll();
        }

        GUILayout.EndHorizontal();

        EditorGUILayout.LabelField("Active Item");
        EditorGUILayout.IntSlider(activeItemIndex, 0, _target.points.Count - 1, new GUIContent("Current Item"));


        _target.UpdateActivePoint();

        Rect position = EditorGUILayout.GetControlRect();

        GUIContent label = EditorGUI.BeginProperty(position, new GUIContent("Active Point"), activeItem);
        Rect contentPosition = EditorGUI.PrefixLabel(position, label);
        contentPosition.width *= 0.25f;
        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;
        EditorGUIUtility.labelWidth = 14f;

        SerializedProperty activeItemPos = activeItem.FindPropertyRelative("position");

        EditorGUI.PropertyField(contentPosition, activeItemPos.FindPropertyRelative("x"));

        contentPosition.x += contentPosition.width;
        EditorGUI.PropertyField(contentPosition, activeItemPos.FindPropertyRelative("y"));

        contentPosition.x += contentPosition.width;
        EditorGUI.PropertyField(contentPosition, activeItemPos.FindPropertyRelative("z"));

        contentPosition.x += contentPosition.width;
        EditorGUI.PropertyField(contentPosition, activeItem.FindPropertyRelative("gravity"), new GUIContent("G"));

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();

        //
        serializedObject.ApplyModifiedProperties();
    }
}

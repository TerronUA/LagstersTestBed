using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(GravityManager))]
public class GravityManagerEditor : Editor
{
    public int activeItemIndex = -1;
    GravityManager _target;

    void Awake()
    {
        _target = target as GravityManager;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Label("Gravity Item Creation");
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Add"))
        {
            _target.activeIndex = _target.AddPoint();
        }
        GUILayout.Button("Delete");

        GUILayout.EndHorizontal();

        //GUILayout.BeginHorizontal();
        GUILayout.Label("Active Item:");
        _target.activeIndex = (int)GUILayout.HorizontalSlider(_target.activeIndex, 0, _target.points.Count);

        // "yourPropertyName" is the name of a property which has a custom property drawer
        // implemented for its class type
        //if (_target.activePoint)
        //{
            //var serializedObject = new UnityEditor.SerializedObject(_target.activePoint);

        //}

        EditorGUILayout.PropertyField(serializedObject.FindProperty("activePoint"));
    }
}

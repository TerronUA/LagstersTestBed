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
            Undo.RecordObject(_target, "GravityManager.AddPoint()");
        }
        if (GUILayout.Button("Delete"))
        {
            _target.DeletePoint();
            Undo.RecordObject(_target, "GravityManager.DeletePoint()");
        }

        GUILayout.EndHorizontal();

        //GUILayout.BeginHorizontal();
        GUILayout.Label("Active Item:");
        _target.activeIndex = (int)GUILayout.HorizontalSlider(_target.activeIndex, 0, _target.points.Count);

        // "yourPropertyName" is the name of a property which has a custom property drawer
        // implemented for its class type
        if (_target.activePoint != null)
        {
            //Object onj = (Object)_target.activePoint;
            //var sObject = new UnityEditor.SerializedObject(onj);
            //var sProp = sObject.FindProperty("position");
            //EditorGUILayout.PropertyField(sProp);
            if (serializedObject != null)
            {
             //   EditorGUILayout.PropertyField(serializedObject.FindProperty("activePoint"));
            }

        }

        //
    }
}

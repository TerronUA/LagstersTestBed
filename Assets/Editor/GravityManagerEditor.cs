using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(GravityManager))]
public class GravityManagerEditor : Editor
{
    public int activeItemIndex = -1;

    public override void OnInspectorGUI()
    {
        GravityManager _target = target as GravityManager;

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
        //GUILayout.EndHorizontal();
        
    }
}

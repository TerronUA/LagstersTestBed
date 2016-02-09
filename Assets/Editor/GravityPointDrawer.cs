using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(GravityPoint))]
public class GravityPointDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty gravityPosition = property.FindPropertyRelative("position");
        SerializedProperty gravityValue = property.FindPropertyRelative("gravity");
        
        float propWidth = position.width/3.0f;

        //EditorGUI.LabelField(new Rect(position.x, position.y, propWidth, position.height), );
        gravityPosition.vector3Value = EditorGUI.Vector3Field(new Rect(position.x, position.y, position.width, position.height), "Position", gravityPosition.vector3Value);

        //EditorGUI.LabelField(new Rect(position.x + propWidth * 2, position.y, propWidth, position.height), "Y");
        //y.boolValue = EditorGUI.Toggle(new Rect(position.x + propWidth * 3, position.y, propWidth, position.height), y.boolValue);

        //EditorGUI.LabelField(new Rect(position.x + propWidth * 4, position.y, propWidth, position.height), "Z");
        //z.boolValue = EditorGUI.Toggle(new Rect(position.x + propWidth * 5, position.y, propWidth, position.height), z.boolValue);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label);
    }
}

using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(PopupAttribute))]
public class PopupAttributeDrawer : PropertyDrawer {

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        var totalPosition = position;
        var propPosition = EditorGUI.PrefixLabel(position, label);

        EditorGUI.PropertyField(propPosition, property, GUIContent.none);
        if (property.objectReferenceValue == null)
            return;

        var hittingControlLeftClick = Event.current.type == EventType.MouseDown && 
                                       Event.current.control && 
                                       Event.current.button == 0;

        if (hittingControlLeftClick) {
            var mouseOverLabel = totalPosition.Contains(Event.current.mousePosition) && 
                                 !propPosition.Contains(Event.current.mousePosition);
            if (mouseOverLabel) {
                PopupEditor.ShowEditorFor(property.objectReferenceValue);
            }
        }
    }
}
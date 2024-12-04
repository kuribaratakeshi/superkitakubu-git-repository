using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditorInternal;
/// <summary>
/// アイテムデータのインスペクターを拡張するEditorくらす
/// </summary>
[CustomEditor(typeof(ItemEventData))]
public class ItemDataEditor : Editor
{
    private ReorderableList reorderableList;
    private SerializedProperty actionDataList;
 
    private void OnEnable()
    {
        actionDataList = serializedObject.FindProperty("actionList");
 
        reorderableList = new ReorderableList(serializedObject, actionDataList);
        reorderableList.drawElementCallback = (rect, index, active, focused) => {
            var actionData = actionDataList.GetArrayElementAtIndex(index);
            EditorGUI.PropertyField(rect, actionData);
        };
        reorderableList.drawHeaderCallback = (rect) => EditorGUI.LabelField(rect, "Event List");
        reorderableList.elementHeightCallback = index => EditorGUI.GetPropertyHeight(actionDataList.GetArrayElementAtIndex(index));
    }
 
    public override void OnInspectorGUI()
    {
        var eventId = serializedObject.FindProperty("eventId");
        EditorGUILayout.PropertyField(eventId);
 
        serializedObject.Update();
        reorderableList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}

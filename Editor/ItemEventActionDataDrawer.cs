using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static CharacterStatus;

[CustomPropertyDrawer(typeof(ItemActionData))]
public class ItemEventActionDataDrawer : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // List�p��1�̃v���p�e�B�ł��邱�Ƃ���������PropertyScope�ň͂�
        using (new EditorGUI.PropertyScope(position, label, property))
        {
            // 0�w�肾��ReorderableList�̃h���b�O�Ɣ��̂�LineHeight���w��
            position.height = EditorGUIUtility.singleLineHeight;

            var actionTypeRect = new Rect(position)
            {
                y = position.y
            };

            var actionTypeProperty = property.FindPropertyRelative("actionType");
            actionTypeProperty.enumValueIndex = EditorGUI.Popup(actionTypeRect, "����", actionTypeProperty.enumValueIndex, Enum.GetNames(typeof(ItemActionType)));

            switch ((ItemActionType)actionTypeProperty.enumValueIndex)
            {
             
             
                case ItemActionType.SPEED:
                    var changeSpeedRect = new Rect(actionTypeRect)
                    {
                        y = actionTypeRect.y + EditorGUIUtility.singleLineHeight + 2f

                    };
                    var changespeedProperty = property.FindPropertyRelative("setspeed");
                    changespeedProperty.floatValue = EditorGUI.FloatField(changeSpeedRect, "���ʎ��̑��x", changespeedProperty.floatValue);
                   
                    
                    var changeSpeedRect1 = new Rect(changeSpeedRect)
                    {
                        y = changeSpeedRect.y + EditorGUIUtility.singleLineHeight + 2f

                    };
                    var channgtimeProperty = property.FindPropertyRelative("effecttime");
                    channgtimeProperty.floatValue = EditorGUI.FloatField(changeSpeedRect1, "���ʎ���", channgtimeProperty.floatValue);

                    var speedTypeSelectRect = new Rect(changeSpeedRect1)
                    {
                        y = changeSpeedRect1.y + EditorGUIUtility.singleLineHeight + 2f
                    };
                    var speedTypeSelectProperty =property.FindPropertyRelative("selectCharacterType");
                    speedTypeSelectProperty.enumValueIndex = EditorGUI.Popup(speedTypeSelectRect, "���x��ς���L�����N�^�[", speedTypeSelectProperty.enumValueIndex, Enum.GetNames(typeof(CharacterType)));

                    break;
                case ItemActionType.DAMEGE:
                    var addDamegeRect = new Rect(actionTypeRect)
                    {
                        y = actionTypeRect.y + EditorGUIUtility.singleLineHeight + 2f

                    };
                    var addDamageProperty =  property.FindPropertyRelative("damege");

                    addDamageProperty.intValue = EditorGUI.IntField(addDamegeRect, "�_���[�W", addDamageProperty.intValue);
                    var damegeTypeSelectRect = new Rect(addDamegeRect)
                    {
                        y = addDamegeRect.y + EditorGUIUtility.singleLineHeight + 2f
                    }; 
                    var damegeTypeSelectProperty = property.FindPropertyRelative("selectCharacterType");
                    damegeTypeSelectProperty.enumValueIndex = EditorGUI.Popup(damegeTypeSelectRect, "�_���[�W��^����L�����N�^�[", damegeTypeSelectProperty.enumValueIndex, Enum.GetNames(typeof(CharacterType)));

                    break;
                case ItemActionType.REPULSION:
                    var repulsionRect = new Rect(actionTypeRect)
                    {
                        y = actionTypeRect.y + EditorGUIUtility.singleLineHeight + 2f
                    };

                    var repulsionValueProperty = property.FindPropertyRelative("repulsionvalue");

                    repulsionValueProperty.floatValue = EditorGUI.FloatField(repulsionRect, "�������ɗ^�����", repulsionValueProperty.floatValue);

                    var repulsionTypeSelectRect = new Rect(repulsionRect)
                    {
                        y = repulsionRect.y + EditorGUIUtility.singleLineHeight + 2f
                    };
                    var repulsionTypeSelectProperty = property.FindPropertyRelative("selectCharacterType");
                    repulsionTypeSelectProperty.enumValueIndex = EditorGUI.Popup(repulsionTypeSelectRect, "������^����L�����N�^�[", repulsionTypeSelectProperty.enumValueIndex, Enum.GetNames(typeof(CharacterType)));


                    break;
                case ItemActionType.DESTORY_MY_SELF:
                    var destoryMySelfRect = new Rect(actionTypeRect)
                    {
                        y = actionTypeRect.y + EditorGUIUtility.singleLineHeight + 2f
                    };
                    var destoryMySelfValueProperty = property.FindPropertyRelative("destoyObj");
                    destoryMySelfValueProperty.objectReferenceValue= EditorGUI.ObjectField(destoryMySelfRect,"�j�󎞂̃G�t�F�N�g", destoryMySelfValueProperty.objectReferenceValue, typeof(GameObject));


                    EditorGUILayout.HelpBox("DESTORY_MY_SELF�̓��X�g�̍Ō�ɔz�u���Ă��������B", MessageType.Info);


                    break;
            }
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var height = EditorGUIUtility.singleLineHeight;

        var actionTypeProperty = property.FindPropertyRelative("actionType");
        switch ((ItemActionType)actionTypeProperty.enumValueIndex)
        {

            case ItemActionType.SPEED:
                height = 100f;
                break;
            case ItemActionType.DAMEGE:
                height = 70f;
                break;
            case ItemActionType.REPULSION:
                height = 70f;
                break;
            case ItemActionType.DESTORY_MY_SELF:
                height = 70f;
                break;
        }

        return height;
    }
}

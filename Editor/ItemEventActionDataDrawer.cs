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
        // List用に1つのプロパティであることを示すためPropertyScopeで囲む
        using (new EditorGUI.PropertyScope(position, label, property))
        {
            // 0指定だとReorderableListのドラッグと被るのでLineHeightを指定
            position.height = EditorGUIUtility.singleLineHeight;

            var actionTypeRect = new Rect(position)
            {
                y = position.y
            };

            var actionTypeProperty = property.FindPropertyRelative("actionType");
            actionTypeProperty.enumValueIndex = EditorGUI.Popup(actionTypeRect, "効果", actionTypeProperty.enumValueIndex, Enum.GetNames(typeof(ItemActionType)));

            switch ((ItemActionType)actionTypeProperty.enumValueIndex)
            {
             
             
                case ItemActionType.SPEED:
                    var changeSpeedRect = new Rect(actionTypeRect)
                    {
                        y = actionTypeRect.y + EditorGUIUtility.singleLineHeight + 2f

                    };
                    var changespeedProperty = property.FindPropertyRelative("setspeed");
                    changespeedProperty.floatValue = EditorGUI.FloatField(changeSpeedRect, "効果時の速度", changespeedProperty.floatValue);
                   
                    
                    var changeSpeedRect1 = new Rect(changeSpeedRect)
                    {
                        y = changeSpeedRect.y + EditorGUIUtility.singleLineHeight + 2f

                    };
                    var channgtimeProperty = property.FindPropertyRelative("effecttime");
                    channgtimeProperty.floatValue = EditorGUI.FloatField(changeSpeedRect1, "効果時間", channgtimeProperty.floatValue);

                    var speedTypeSelectRect = new Rect(changeSpeedRect1)
                    {
                        y = changeSpeedRect1.y + EditorGUIUtility.singleLineHeight + 2f
                    };
                    var speedTypeSelectProperty =property.FindPropertyRelative("selectCharacterType");
                    speedTypeSelectProperty.enumValueIndex = EditorGUI.Popup(speedTypeSelectRect, "速度を変えるキャラクター", speedTypeSelectProperty.enumValueIndex, Enum.GetNames(typeof(CharacterType)));

                    break;
                case ItemActionType.DAMEGE:
                    var addDamegeRect = new Rect(actionTypeRect)
                    {
                        y = actionTypeRect.y + EditorGUIUtility.singleLineHeight + 2f

                    };
                    var addDamageProperty =  property.FindPropertyRelative("damege");

                    addDamageProperty.intValue = EditorGUI.IntField(addDamegeRect, "ダメージ", addDamageProperty.intValue);
                    var damegeTypeSelectRect = new Rect(addDamegeRect)
                    {
                        y = addDamegeRect.y + EditorGUIUtility.singleLineHeight + 2f
                    }; 
                    var damegeTypeSelectProperty = property.FindPropertyRelative("selectCharacterType");
                    damegeTypeSelectProperty.enumValueIndex = EditorGUI.Popup(damegeTypeSelectRect, "ダメージを与えるキャラクター", damegeTypeSelectProperty.enumValueIndex, Enum.GetNames(typeof(CharacterType)));

                    break;
                case ItemActionType.REPULSION:
                    var repulsionRect = new Rect(actionTypeRect)
                    {
                        y = actionTypeRect.y + EditorGUIUtility.singleLineHeight + 2f
                    };

                    var repulsionValueProperty = property.FindPropertyRelative("repulsionvalue");

                    repulsionValueProperty.floatValue = EditorGUI.FloatField(repulsionRect, "反発時に与える力", repulsionValueProperty.floatValue);

                    var repulsionTypeSelectRect = new Rect(repulsionRect)
                    {
                        y = repulsionRect.y + EditorGUIUtility.singleLineHeight + 2f
                    };
                    var repulsionTypeSelectProperty = property.FindPropertyRelative("selectCharacterType");
                    repulsionTypeSelectProperty.enumValueIndex = EditorGUI.Popup(repulsionTypeSelectRect, "反発を与えるキャラクター", repulsionTypeSelectProperty.enumValueIndex, Enum.GetNames(typeof(CharacterType)));


                    break;
                case ItemActionType.DESTORY_MY_SELF:
                    var destoryMySelfRect = new Rect(actionTypeRect)
                    {
                        y = actionTypeRect.y + EditorGUIUtility.singleLineHeight + 2f
                    };
                    var destoryMySelfValueProperty = property.FindPropertyRelative("destoyObj");
                    destoryMySelfValueProperty.objectReferenceValue= EditorGUI.ObjectField(destoryMySelfRect,"破壊時のエフェクト", destoryMySelfValueProperty.objectReferenceValue, typeof(GameObject));


                    EditorGUILayout.HelpBox("DESTORY_MY_SELFはリストの最後に配置してください。", MessageType.Info);


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

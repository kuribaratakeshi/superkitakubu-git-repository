using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterStatus;


[Serializable]
[CreateAssetMenu(menuName = "ScriptableObject/ItemEventData")]

public class ItemEventData : ScriptableObject
{
    public int eventId;
    public List<ItemActionData> actionList;

}
[Serializable]
public class ItemActionData
{
    public ItemActionType actionType;
    public string talkName;
    [TextArea]
    
    public string talkText;
    public Vector3 localMovePoint;
    public string animationName;

    public float setspeed;
    public float effecttime;



    public CharacterType selectCharacterType;
    public int damege;


    public float repulsionvalue;

    public GameObject destoyObj;


}




public enum ItemActionType
{

    SPEED,
    DAMEGE,
    REPULSION,
    DESTORY_MY_SELF,
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterStatus;

public class OnActiveCharacter : UseEffectBase
{

    private bool _canTask=false;

    public bool CurrentCan
    {

        get { return _canTask; }
        set { _canTask = value; }

    }

    private void OnTriggerEnter(Collider other)
    {

        if(_canTask==true) { CheckCharacter(other); }
        
    }



    /// <summary>
    /// エネミーとアイテムに設置処理を行う。
    /// </summary>
    /// <param name="other"></param>
    private void CheckCharacter(Collider other)
    {

        if(other.gameObject != null)
        {
            if (HasCharacterStatus(other.gameObject) == true)
            {                 //効果を与えるタイプと一致しているか？
                if (CheckCharacterType(other.gameObject) == CharacterType.ENEMY || CheckCharacterType(other.gameObject) == CharacterType.ITEM)
                {

              
                    IChangeSpeed changespeed = other.gameObject.GetComponent<IChangeSpeed>();

                    if (changespeed != null)
                    {

                        
                        changespeed.ResetSpeed();


                    }


                }


            }

        }



    
    }




}

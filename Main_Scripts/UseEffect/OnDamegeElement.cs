using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterStatus))]
//自身と異なるキャラクタータイプに対してダメージを与えるコンポーネント
public class OnDamegeElement:UseEffectBase
{

    public int damege = 1;

    CharacterStatus _characterstatus;
    // Start is called before the first frame update
    void Start()
    {
        _characterstatus = GetComponent<CharacterStatus>();
    }

    
    private void OnCollisionEnter(Collision collision)
    {



        AtackDifferentCharacter(collision);



    }

    /// <summary>
    /// 自分と列挙子が異なるキャラクターにダメージを与える。
    /// </summary>
    /// <param name="collision"></param>
    private void AtackDifferentCharacter(Collision collision)
    {


        IDamage _damageable = collision.gameObject.GetComponent<IDamage>();

        if (_damageable != null)
        {
            //相手が自分と異なるキャラクタータイプ
            if (CheckSameCharacterType(this._characterstatus,collision)==false)
            {
                
                //触れた相手のhpが0以下ではないかを確認する。
               if (CheckCharacterNOHP(collision.gameObject) ==false)
                {

                    _damageable.Damage(damege);
                }
            }



         

        }




    }



}

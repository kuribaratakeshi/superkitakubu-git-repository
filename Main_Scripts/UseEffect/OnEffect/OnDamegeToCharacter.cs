
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterStatus;
/// <summary>
/// キャラクターにダメージを与えるスクリプト
/// ダメージを与えるタイプ決定して一定時間後にダメージを与える。
/// </summary>
public class OnDamegeToCharacter : UseEffectBase
{

    private int _damege;
    //private GameObject _settarget;
    private CharacterType _damegeCharacterType;
    /// <summary>
    /// 接触してきたオブジェクトに対して、一定時間後に効果を及ぼす際に最初に設定する
    /// </summary>

    public void SetDamege(AddEffectBase effectBase,int damege,CharacterType demegecharacter)
    {
        _addEffectBase= effectBase;
        _damegeCharacterType = demegecharacter;
        _damege= damege;    
        //即発動のため0f
        base.SetUp(0f);
    }


    /// <summary>
    /// 効果時間に達した時の処理
    /// </summary>

    protected override void SetLastEffect()
    {
  
        IDamage _damageable = this.gameObject.GetComponent<IDamage>();

        if (_damageable != null)
        {
            //ステータスがあるのか
            if (HasCharacterStatus(this.gameObject) == true)
            {                 //ダメージを与えるタイプと一致しているか？
                if (CheckCharacterType(this.gameObject) == _damegeCharacterType)
                {
                    //ダメージを与えるときにhpが0以下ではないかを確認する。
                    if (CheckCharacterNOHP(this.gameObject) == false)
                    {
                        CollbackToAddEffectBase();
                        _damageable.Damage(_damege);
                    }
                }


            }
        }

    }


}

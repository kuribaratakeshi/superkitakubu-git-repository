using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterStatus;

public class OnRepulsionToCharacter : UseEffectBase
{



    private float _forceValue =10f;

    private CharacterType _repulsionCharacterType;

    private Collision _collision;
    /// <summary>
    /// 接触してきたオブジェクトに対して、一定時間後に効果を及ぼす際に最初に設定する
    /// </summary>

    public void SetRepulsion(AddEffectBase effectBase,Collision collision, float forceValue, CharacterType demegecharacter)
    {
        _collision = collision;
        _addEffectBase = effectBase;
        _repulsionCharacterType = demegecharacter;
        _forceValue = forceValue;
        //即発動のため0f
        base.SetUp(0f);
    }


    /// <summary>
    /// 効果時間に達した時の処理
    /// </summary>

    protected override void SetLastEffect()
    {
            //ステータスがあるのか
            if (HasCharacterStatus(this.gameObject) == true)
            {                 //効果を与えるタイプと一致しているか？
                if (CheckCharacterType(this.gameObject) == _repulsionCharacterType)
                {
                    
                    if(_collision != null)
                    {
                    //Rigidbodyがアタッチされているか
                        if (HasCheckRigidbody(this.gameObject) == true)
                        {
                            EffectRepulsion();
                            CollbackToAddEffectBase();

                        }
                    }
                        
                }
            }
    }


    private void EffectRepulsion()
    {

       
        var rb = this.gameObject.GetComponent<Rigidbody>();
        //接触時の法線を取得する。
        Vector3 velocity
        = Vector3.Reflect(rb.velocity, _collision.contacts[0].normal);

        //法線方向に力を加える。
        rb.AddForce(velocity * _forceValue, ForceMode.Impulse);

    }

}

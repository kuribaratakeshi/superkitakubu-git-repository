using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using static CharacterStatus;

public class UseEffectBase : MonoBehaviour
{

    protected bool _isSetUp =false;
    protected float _timer=0f;
    protected float _endTime;

    //コールバックに必要
    protected AddEffectBase _addEffectBase;


    void Update()
    {

        CheckStatus();

        if (_isSetUp)
        {
            _timer += Time.deltaTime;
            if (_timer >= _endTime)
            {
                SetLastEffect();
               // Debug.Log("UseEffect削除");
                Destroy(this);
            }
            
        }
        else
        {
            return;
        }



    }
    /// <summary>
    /// ステータスを確認する。
    /// </summary>
    protected virtual void CheckStatus()
    {



    }


    /// <summary>
    /// 効果時間がある処理を行いたい場合に最初に呼び出す。
    /// </summary>
    /// <param name="setTime"></param>
    public virtual void SetUp(float setTime)
    {
        _endTime= setTime;
        _isSetUp= true;
        SetFirstEffect();

    }


    /// <summary>
    /// 効果が始まった時の処理
    /// </summary>
    protected virtual void SetFirstEffect()
    {


    }

    /// <summary>
    /// 効果時間に達した時の処理
    /// </summary>

    protected virtual void SetLastEffect()
    {
 

    }



    /// <summary>
    /// 列挙子が一致しているかを判定する
    /// </summary>
    /// <param name="characterStatus"></param>
    /// <param name="collision"></param>
    /// <returns></returns>
    protected virtual bool CheckSameCharacterType(CharacterStatus characterStatus,Collision collision)
    {

        bool isSameType = false;

        if(characterStatus != null) {

            var touchobj = collision.gameObject.GetComponent<CharacterStatus>();

            if (touchobj != null)
            {
                if (characterStatus.CurrentCharacterType == touchobj.CurrentCharacterType)
                {
                    isSameType = true;
                }
            }


        }

        return isSameType;


    }


    /// <summary>
    /// 検証したいキャラクターのhpを受け取り0以下であるかを判定する
    /// </summary>
    /// <param name="checkobj"></param>
    /// <returns></returns>

    protected virtual bool CheckCharacterNOHP(GameObject checkobj)
    {

        var  characterStatus = checkobj.GetComponent<CharacterStatus>();
        bool canDeleteCharacter = false;
        if (characterStatus != null)
        {
            
            var chp = characterStatus.CurrentHP;
           
           

            if (chp <= 0)
            {
                canDeleteCharacter = true;

            }


          

        }


        return canDeleteCharacter;
    }
    /// <summary>
    /// キャラクターステータスがあるかを確認する。
    /// </summary>
    /// <param name="checkobj"></param>
    /// <returns></returns>
    protected virtual bool HasCharacterStatus(GameObject checkobj)
    {
        bool hasCharacterStatus = false;

        var characterStatus = checkobj.GetComponent<CharacterStatus>();

        if (characterStatus != null)
        {

            hasCharacterStatus = true;
        }



        return hasCharacterStatus;

    }

    /// <summary>
    /// オブジェクトのタイプを確認し、オブジェクトの列挙子を返す。
    /// </summary>
    /// <param name="checkobj"></param>
    protected virtual CharacterType CheckCharacterType(GameObject checkobj)
    {


        var characterStatus = checkobj.GetComponent<CharacterStatus>();
        var mytype = characterStatus.CurrentCharacterType;

        return mytype;
    }
    /// <summary>
    /// rigidbodyを持っているかを確認する。
    /// </summary>
    /// <param name="checkobj"></param>
    /// <returns></returns>
    protected virtual bool HasCheckRigidbody(GameObject checkobj)
    {
        bool hasRigidbody = false;

        var rigidbody = checkobj.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            hasRigidbody = true;

        }



        return hasRigidbody;

    }
    /// <summary>
    /// AddEffectBaseにコールバックを返す
    /// </summary>
    protected virtual void CollbackToAddEffectBase()
    {
        if (_addEffectBase != null)
        {

            _addEffectBase.CountEffect();

        }



    }
    
    


}

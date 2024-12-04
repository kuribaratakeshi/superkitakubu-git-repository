using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 接触時に、自身のオブジェクトのhpが0いかになったとき、接触したオブジェクトの進行方向に飛ばされ
/// その後、自身のオブジェクトを削除する。
/// </summary>
/// 
[RequireComponent(typeof(CharacterStatus))]
public class OnCheckDelete : UseEffectBase
{
    [SerializeField] private float _velocityforceAmount = 10f;
    [SerializeField] private float _upforceAmount = 10f;
    private CharacterStatus _characterstatus;

    [SerializeField] private float _swaittime = 3f;
    [SerializeField] GameObject _SParticle;
    [SerializeField] bool _hastask=false;

    Collision _collision;

    void Start()
    {
        _characterstatus = GetComponent<CharacterStatus>();

    }

    void OnCollisionEnter(Collision collision)
    {

        this._collision = collision;

    }
    protected override void CheckStatus()
    {

        if (_hastask == true)
        {
            return;
        }


        if (_characterstatus != null)
        {
            
            //自身のhpの確認
            if (CheckCharacterNOHP(this.gameObject))
            {

                if(_collision!= null)
                {
                    if (_hastask == false)
                    {


                        _hastask = true;
                        //キャラクターに力を与える
                        PushCharacter(_collision);
                        //setup関数に秒数を記述し、設定時間後に削除する。
                        SetUp(_swaittime);


                    }

                }
                

            }

        }



    }


    /// <summary>
    /// 効果時間に達した時の処理
    /// </summary>

    protected override void SetLastEffect()
    {
        //エフェクト作成
        if (_SParticle != null)
        {
            //プレハブ
            GameObject particle = (GameObject)Instantiate(_SParticle, transform.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0));
        }

        //Debug.Log(this.gameObject + "削除");
        //本体の削除
        Destroy(this.gameObject);
    }


    /// <summary>
    /// キャラクターに力を与える
    /// </summary>

    private void PushCharacter(Collision collision)
    {
        var mytype = _characterstatus.CurrentCharacterType;

        

        Vector3 forceDirection = collision.contacts[0].normal; // 衝突された方向の法線ベクトル
       // var collider = this.gameObject.GetComponent<BoxCollider>();
       // collider.enabled = false;
        var rb = this.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(rb.velocity * _velocityforceAmount, ForceMode.Impulse);
            rb.AddForce(Vector3.up * _upforceAmount, ForceMode.Impulse);
        }

    }

}


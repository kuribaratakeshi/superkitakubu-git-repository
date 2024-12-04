using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRepulsion : UseEffectBase
{
    [SerializeField] private float _velocityforceAmount = 10f;
    [SerializeField] private float _upforceAmount = 10f;
    CharacterStatus _characterstatus;


    [SerializeField] bool _hastask = false;

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

                if (_collision != null)
                {
                    if (_hastask == false)
                    {   
                        _hastask = true;
                        //プレイヤーの動きを止める
                        StopPlayerMovement();
                        //キャラクターに力を与える
                        PushCharacter();
                     
                    }

                }

            }

        }



    }




    /// <summary>
    /// キャラクターに力を与える
    /// </summary>

    private void PushCharacter()
    {
        var mytype = _characterstatus.CurrentCharacterType;
    // 衝突された方向の法線ベクトル
                                                               // var collider = this.gameObject.GetComponent<BoxCollider>();
                                                               // collider.enabled = false;
        var rb = this.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            //接触時の法線を取得する。
            Vector3 velocity
            = Vector3.Reflect(rb.velocity, _collision.contacts[0].normal);

            //法線方向に力を加える。
            rb.AddForce(velocity * _velocityforceAmount, ForceMode.Impulse);

            rb.AddForce(Vector3.up * _upforceAmount, ForceMode.Impulse);
            
        }



    }


    private void StopPlayerMovement()
    {

        var playermovement   = this.gameObject.GetComponent<ThroughMovement>();
        if (playermovement != null)
        playermovement.SetCanNotMove();
    }


}

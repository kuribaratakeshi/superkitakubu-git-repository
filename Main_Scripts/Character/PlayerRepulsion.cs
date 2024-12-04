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

            //���g��hp�̊m�F
            if (CheckCharacterNOHP(this.gameObject))
            {

                if (_collision != null)
                {
                    if (_hastask == false)
                    {   
                        _hastask = true;
                        //�v���C���[�̓������~�߂�
                        StopPlayerMovement();
                        //�L�����N�^�[�ɗ͂�^����
                        PushCharacter();
                     
                    }

                }

            }

        }



    }




    /// <summary>
    /// �L�����N�^�[�ɗ͂�^����
    /// </summary>

    private void PushCharacter()
    {
        var mytype = _characterstatus.CurrentCharacterType;
    // �Փ˂��ꂽ�����̖@���x�N�g��
                                                               // var collider = this.gameObject.GetComponent<BoxCollider>();
                                                               // collider.enabled = false;
        var rb = this.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            //�ڐG���̖@�����擾����B
            Vector3 velocity
            = Vector3.Reflect(rb.velocity, _collision.contacts[0].normal);

            //�@�������ɗ͂�������B
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

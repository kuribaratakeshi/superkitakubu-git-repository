using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ڐG���ɁA���g�̃I�u�W�F�N�g��hp��0�����ɂȂ����Ƃ��A�ڐG�����I�u�W�F�N�g�̐i�s�����ɔ�΂���
/// ���̌�A���g�̃I�u�W�F�N�g���폜����B
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
            
            //���g��hp�̊m�F
            if (CheckCharacterNOHP(this.gameObject))
            {

                if(_collision!= null)
                {
                    if (_hastask == false)
                    {


                        _hastask = true;
                        //�L�����N�^�[�ɗ͂�^����
                        PushCharacter(_collision);
                        //setup�֐��ɕb�����L�q���A�ݒ莞�Ԍ�ɍ폜����B
                        SetUp(_swaittime);


                    }

                }
                

            }

        }



    }


    /// <summary>
    /// ���ʎ��ԂɒB�������̏���
    /// </summary>

    protected override void SetLastEffect()
    {
        //�G�t�F�N�g�쐬
        if (_SParticle != null)
        {
            //�v���n�u
            GameObject particle = (GameObject)Instantiate(_SParticle, transform.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0));
        }

        //Debug.Log(this.gameObject + "�폜");
        //�{�̂̍폜
        Destroy(this.gameObject);
    }


    /// <summary>
    /// �L�����N�^�[�ɗ͂�^����
    /// </summary>

    private void PushCharacter(Collision collision)
    {
        var mytype = _characterstatus.CurrentCharacterType;

        

        Vector3 forceDirection = collision.contacts[0].normal; // �Փ˂��ꂽ�����̖@���x�N�g��
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


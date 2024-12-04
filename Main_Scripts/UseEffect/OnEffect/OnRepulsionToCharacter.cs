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
    /// �ڐG���Ă����I�u�W�F�N�g�ɑ΂��āA��莞�Ԍ�Ɍ��ʂ��y�ڂ��ۂɍŏ��ɐݒ肷��
    /// </summary>

    public void SetRepulsion(AddEffectBase effectBase,Collision collision, float forceValue, CharacterType demegecharacter)
    {
        _collision = collision;
        _addEffectBase = effectBase;
        _repulsionCharacterType = demegecharacter;
        _forceValue = forceValue;
        //�������̂���0f
        base.SetUp(0f);
    }


    /// <summary>
    /// ���ʎ��ԂɒB�������̏���
    /// </summary>

    protected override void SetLastEffect()
    {
            //�X�e�[�^�X������̂�
            if (HasCharacterStatus(this.gameObject) == true)
            {                 //���ʂ�^����^�C�v�ƈ�v���Ă��邩�H
                if (CheckCharacterType(this.gameObject) == _repulsionCharacterType)
                {
                    
                    if(_collision != null)
                    {
                    //Rigidbody���A�^�b�`����Ă��邩
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
        //�ڐG���̖@�����擾����B
        Vector3 velocity
        = Vector3.Reflect(rb.velocity, _collision.contacts[0].normal);

        //�@�������ɗ͂�������B
        rb.AddForce(velocity * _forceValue, ForceMode.Impulse);

    }

}

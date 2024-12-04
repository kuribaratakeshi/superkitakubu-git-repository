
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterStatus;
/// <summary>
/// �L�����N�^�[�Ƀ_���[�W��^����X�N���v�g
/// �_���[�W��^����^�C�v���肵�Ĉ�莞�Ԍ�Ƀ_���[�W��^����B
/// </summary>
public class OnDamegeToCharacter : UseEffectBase
{

    private int _damege;
    //private GameObject _settarget;
    private CharacterType _damegeCharacterType;
    /// <summary>
    /// �ڐG���Ă����I�u�W�F�N�g�ɑ΂��āA��莞�Ԍ�Ɍ��ʂ��y�ڂ��ۂɍŏ��ɐݒ肷��
    /// </summary>

    public void SetDamege(AddEffectBase effectBase,int damege,CharacterType demegecharacter)
    {
        _addEffectBase= effectBase;
        _damegeCharacterType = demegecharacter;
        _damege= damege;    
        //�������̂���0f
        base.SetUp(0f);
    }


    /// <summary>
    /// ���ʎ��ԂɒB�������̏���
    /// </summary>

    protected override void SetLastEffect()
    {
  
        IDamage _damageable = this.gameObject.GetComponent<IDamage>();

        if (_damageable != null)
        {
            //�X�e�[�^�X������̂�
            if (HasCharacterStatus(this.gameObject) == true)
            {                 //�_���[�W��^����^�C�v�ƈ�v���Ă��邩�H
                if (CheckCharacterType(this.gameObject) == _damegeCharacterType)
                {
                    //�_���[�W��^����Ƃ���hp��0�ȉ��ł͂Ȃ������m�F����B
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterStatus;

public class InSpeedEffect : UseEffectBase
{

    [SerializeField] private float _changespeed = 20f;

    
    private CharacterType _speedCharacterType;


    private bool _hasTask = false;


    public bool CurrentTask
    {

        get { return _hasTask; }
        set { _hasTask = value; }

    }

    public void SetChangeSpeed(AddEffectBase effectBase,float settime,float setSpeed, CharacterType speedCharacter)
    {
            _hasTask = true;
            _addEffectBase = effectBase;
            _speedCharacterType = speedCharacter;
            _changespeed = setSpeed;
            base.SetUp(settime);

    }

    /// <summary>
    /// ���ʂ��n�܂������̏���
    /// </summary>
    protected override void SetFirstEffect()
    {
        //�X�e�[�^�X������̂�
        if (HasCharacterStatus(this.gameObject) == true)
        {
            //���ʂ�^����^�C�v�ƈ�v���Ă��邩�H
            if (CheckCharacterType(this.gameObject) == _speedCharacterType)
            {
                IChangeSpeed changespeed = this.gameObject.GetComponent<IChangeSpeed>();
                Debug.Log(this.gameObject + "atatus" + _speedCharacterType);
                
                if (changespeed != null)
                {

                    CollbackToAddEffectBase();
                    changespeed.ChangeSpeed(_changespeed);


                }

            }
        }

    }

    /// <summary>
    /// ���ʎ��ԂɒB�������̏���
    /// </summary>

    protected override void SetLastEffect()
    {
        
        //�X�e�[�^�X������̂�
        if (HasCharacterStatus(this.gameObject) == true)
        {
            Debug.Log(this.gameObject + "lastsatatus"+ _speedCharacterType);
            //���ʂ�^����^�C�v�ƈ�v���Ă��邩�H
            if (CheckCharacterType(this.gameObject) == _speedCharacterType)
            {
                Debug.Log(this.gameObject + "lasttype");
                IChangeSpeed changespeed = this.gameObject.GetComponent<IChangeSpeed>();
                
                if (changespeed != null)
                {
                    
                    changespeed.ResetSpeed();
                   
                }

            }
        }

    }

}

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

    //�R�[���o�b�N�ɕK�v
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
               // Debug.Log("UseEffect�폜");
                Destroy(this);
            }
            
        }
        else
        {
            return;
        }



    }
    /// <summary>
    /// �X�e�[�^�X���m�F����B
    /// </summary>
    protected virtual void CheckStatus()
    {



    }


    /// <summary>
    /// ���ʎ��Ԃ����鏈�����s�������ꍇ�ɍŏ��ɌĂяo���B
    /// </summary>
    /// <param name="setTime"></param>
    public virtual void SetUp(float setTime)
    {
        _endTime= setTime;
        _isSetUp= true;
        SetFirstEffect();

    }


    /// <summary>
    /// ���ʂ��n�܂������̏���
    /// </summary>
    protected virtual void SetFirstEffect()
    {


    }

    /// <summary>
    /// ���ʎ��ԂɒB�������̏���
    /// </summary>

    protected virtual void SetLastEffect()
    {
 

    }



    /// <summary>
    /// �񋓎q����v���Ă��邩�𔻒肷��
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
    /// ���؂������L�����N�^�[��hp���󂯎��0�ȉ��ł��邩�𔻒肷��
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
    /// �L�����N�^�[�X�e�[�^�X�����邩���m�F����B
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
    /// �I�u�W�F�N�g�̃^�C�v���m�F���A�I�u�W�F�N�g�̗񋓎q��Ԃ��B
    /// </summary>
    /// <param name="checkobj"></param>
    protected virtual CharacterType CheckCharacterType(GameObject checkobj)
    {


        var characterStatus = checkobj.GetComponent<CharacterStatus>();
        var mytype = characterStatus.CurrentCharacterType;

        return mytype;
    }
    /// <summary>
    /// rigidbody�������Ă��邩���m�F����B
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
    /// AddEffectBase�ɃR�[���o�b�N��Ԃ�
    /// </summary>
    protected virtual void CollbackToAddEffectBase()
    {
        if (_addEffectBase != null)
        {

            _addEffectBase.CountEffect();

        }



    }
    
    


}

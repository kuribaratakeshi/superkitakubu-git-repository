using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterStatus;


public class AddEffectBase : MonoBehaviour
{

    public ItemEventData _itemdata;

    private int _effectTimes=0;
    private void OnCollisionEnter(Collision collision)
    {
        CheckMyEffect(collision);
   
    }


    /// <summary>
    /// �^������ʂ𔻒肷��
    /// </summary>
    /// <param name="collision"></param>

    private void CheckMyEffect(Collision collision)
    {

        foreach (var a in _itemdata.actionList)
        {
            
            switch (a.actionType)
            {

                case ItemActionType.SPEED:
                    SetSpeedEffect(collision, a.effecttime, a.setspeed,a.selectCharacterType);
                    break;
                case ItemActionType.DAMEGE:
                    SetDamegeEffect(collision, a.damege, a.selectCharacterType);
                    break;
                case ItemActionType.REPULSION:
                    SetRepulsionEffect(collision,a.repulsionvalue,a.selectCharacterType);
                    break;
                case ItemActionType.DESTORY_MY_SELF:
                    SetDestoryMySelf(a.destoyObj);
                    break;
            }

        }



    }

    /// <summary>
    /// ���x�̕ύX�������s���B
    /// </summary>
    /// <param name="collision"></param>
    /// <param name="effecttime"></param>
    /// <param name="setspeed"></param>
    /// <param name="speedcharacter"></param>
    private void SetSpeedEffect(Collision collision,float effecttime,float setspeed, CharacterType speedcharacter)
    {
        var status =collision.gameObject.GetComponent<CharacterStatus>();
        //�X�e�[�^�X�����邩
        if(status != null)
        {

            //�L�����N�^�[�̗񋓎q��������������
            if(speedcharacter == status.CurrentCharacterType)
            {

                var inspeed = collision.gameObject.GetComponent<InSpeedEffect>();

                if(inspeed == null)
                {

                    InSpeedEffect inspe = collision.gameObject.AddComponent<InSpeedEffect>();
                    inspe.SetChangeSpeed(this, effecttime, setspeed, speedcharacter);


                }
                else
                {
                    Destroy(inspeed);
                    InSpeedEffect inspe = collision.gameObject.AddComponent<InSpeedEffect>();
                    inspe.SetChangeSpeed(this, effecttime, setspeed, speedcharacter);


                }



            }




        }

       
    }

    /// <summary>
    /// hp�֘A�̕ύX�������s���B
    /// </summary>
    /// <param name="collision"></param>
    /// <param name="damege"></param>
    /// <param name="demegecharacter"></param>
    private void SetDamegeEffect(Collision collision, int damege, CharacterType demegecharacter)
    {
        OnDamegeToCharacter ondamege = collision.gameObject.AddComponent<OnDamegeToCharacter>();
        ondamege.SetDamege(this,damege, demegecharacter);
    }

    private void SetRepulsionEffect(Collision collision,float value, CharacterType repulsioncharacter)
    {

        OnRepulsionToCharacter onrepulin = collision.gameObject.AddComponent<OnRepulsionToCharacter>();
        onrepulin.SetRepulsion(this,collision,value,repulsioncharacter);
    }

    /// <summary>
    /// ���g���폜���鏈�����s���B
    /// </summary>
    private void SetDestoryMySelf(GameObject destroyeffect)
    {
        
        if (_effectTimes >= 1)
        {

            OnDestorySelf onDestorySelf = this.gameObject.AddComponent<OnDestorySelf>();
            onDestorySelf.SetDestorySelf(this.gameObject,destroyeffect);

        }



    }
    /// <summary>
    /// �������ꂽ���ʂ��J�E���g���܂�
    /// </summary>
    public void CountEffect()
    {

        _effectTimes++;

    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterStatus))]
//���g�ƈقȂ�L�����N�^�[�^�C�v�ɑ΂��ă_���[�W��^����R���|�[�l���g
public class OnDamegeElement:UseEffectBase
{

    public int damege = 1;

    CharacterStatus _characterstatus;
    // Start is called before the first frame update
    void Start()
    {
        _characterstatus = GetComponent<CharacterStatus>();
    }

    
    private void OnCollisionEnter(Collision collision)
    {



        AtackDifferentCharacter(collision);



    }

    /// <summary>
    /// �����Ɨ񋓎q���قȂ�L�����N�^�[�Ƀ_���[�W��^����B
    /// </summary>
    /// <param name="collision"></param>
    private void AtackDifferentCharacter(Collision collision)
    {


        IDamage _damageable = collision.gameObject.GetComponent<IDamage>();

        if (_damageable != null)
        {
            //���肪�����ƈقȂ�L�����N�^�[�^�C�v
            if (CheckSameCharacterType(this._characterstatus,collision)==false)
            {
                
                //�G�ꂽ�����hp��0�ȉ��ł͂Ȃ������m�F����B
               if (CheckCharacterNOHP(collision.gameObject) ==false)
                {

                    _damageable.Damage(damege);
                }
            }



         

        }




    }



}

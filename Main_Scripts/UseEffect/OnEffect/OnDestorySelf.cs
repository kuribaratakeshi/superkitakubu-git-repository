using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterStatus;
using static UnityEngine.ParticleSystem;

public class OnDestorySelf : UseEffectBase
{

    private GameObject _destoryObj;

    private GameObject _destoryEffect;
    public void SetDestorySelf(GameObject setobj , GameObject destoryEffect)
    {
        _destoryEffect = destoryEffect;
        _destoryObj = setobj;
        //即発動のため0f
        base.SetUp(0f);
    }


    /// <summary>
    /// 効果時間に達した時の処理
    /// </summary>

    protected override void SetLastEffect()
    {

       if(_destoryEffect != null )
        {

            GameObject particle = (GameObject)Instantiate(_destoryEffect, transform.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0));
        }

       if(_destoryObj != null)
        {
            Destroy(_destoryObj);
        }

    }
}

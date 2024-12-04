using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnReciveEffect : UseEffectBase
{


    [SerializeField] private  GameObject _reciveEffect;

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.GetComponent<CharacterStatus>() != null)
        {
            CreateReciveEffect(collision);
        }

    }

    private void CreateReciveEffect(Collision collision)
    {

        GameObject effect = (GameObject)Instantiate(_reciveEffect, collision.contacts[0].point, Quaternion.LookRotation(collision.contacts[0].normal));

    }

}

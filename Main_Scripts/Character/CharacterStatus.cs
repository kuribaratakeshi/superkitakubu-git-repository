using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour, IDamage
{
    
    public enum CharacterType
    {
        MAIN_PLAYER,
        SUB_PLAYER,
        ENEMY,
        ITEM,



    }
    [SerializeField]
    private CharacterType _MyCharacterType;
    public CharacterType CurrentCharacterType
    {
        get { return _MyCharacterType; }
        set { _MyCharacterType = value; }

    }




    [SerializeField] private int _HP;
    public int CurrentHP
    {

        get { return _HP; }
        set { _HP = value; }

    }

    private bool _isDeath=false;
    public bool CurrentIsDeath
    {

        get { return _isDeath; }
        set { _isDeath = value; }

    }

    /// <summary>
    /// ダメージ処理
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        //Debug.Log(this.gameObject+"が"+damage+"ダメージ受けた。");
        _HP -= damage;
        Check();

    }


    private void Check()
    {
        if(_HP<=0) { _isDeath = true; }
       
    }
}

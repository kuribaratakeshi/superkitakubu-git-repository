using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryDistance : MonoBehaviour
{
    [SerializeField]private GameObject Player;
    [SerializeField]private GameObject SubPlayer;
    [SerializeField] private float _destoryDistance = 30f;
    private CharacterStatus _playercharacterstatus;
    private CharacterStatus _subplayercharacterstatus;
    private float _distance = 0f;


    public float CurrentDestoryDistance
    {


        get { return _destoryDistance; }
        set { _destoryDistance = value; }
    }
    public float CurrentDistance
    {

        get { return _distance; }
        set { _distance = value; }

    }


    private void Start()
    {
        _playercharacterstatus = Player.GetComponent<CharacterStatus>();
        _subplayercharacterstatus = SubPlayer.GetComponent<CharacterStatus>();

    }

    // Update is called once per frame
    void Update()
    {
        DistanceCalc();

        CheckDistance();
    }


    /// <summary>
    /// �v���C���[�ƃT�u�v���C���[�̋������v�Z����
    /// </summary>
    private void DistanceCalc()
    {

        _distance = Vector3.Distance(Player.transform.position, SubPlayer.transform.position);
        

    }


    /// <summary>
    /// �������������𒴂��Ă��邩���v�Z����B
    /// </summary>
    private void CheckDistance()
    {
        
        if(_distance > _destoryDistance)
        {
            if(_subplayercharacterstatus.CurrentIsDeath == false)
            {

                _playercharacterstatus.CurrentIsDeath = true;

            }
           

        } 

    }




}

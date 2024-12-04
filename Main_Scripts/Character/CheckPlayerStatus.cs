using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static CharacterStatus;
using static UnityEngine.ParticleSystem;


[RequireComponent(typeof(CharacterStatus))]

public class CheckPlayerStatus : MonoBehaviour
{

    private CharacterStatus _characterStatus;

    private bool _isPlaying = false;

    private int _currentHP = 0;

    [SerializeField]
    private GameObject _Breakeparticle;

    [SerializeField]
    private AudioClip _damegeClip;
    [SerializeField]
    private AudioSource _audioSoruce;
    // Start is called before the first frame update
    void Start()
    {
        _characterStatus = this.gameObject.GetComponent<CharacterStatus>();

        if (_characterStatus != null)
        {

            _currentHP = _characterStatus.CurrentHP;

        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameOver();
        CheckDamege();

    }



    /// <summary>
    /// ダメージを受けたか確認する。
    /// </summary>

    private void CheckDamege()
    {
        if(_currentHP > _characterStatus.CurrentHP)
        {
            _currentHP = _characterStatus.CurrentHP;
            PlaySound(_damegeClip);

        }
        


    }

    private void PlaySound(AudioClip audioClip) {

        _audioSoruce.PlayOneShot(audioClip);


    }

    /// <summary>
    /// ゲームオーバー条件に達しているか確認する。
    /// </summary>

    private void CheckGameOver()
    {
        if (_characterStatus.CurrentIsDeath == true)
        {
            if (_isPlaying == true)
            {
                RemovePlayer();
            }
            _isPlaying = false;

        }
        else
        {
            _isPlaying = true;

        }
    }

    /// <summary>
    /// プレイヤーゲームオーバー処理
    /// </summary>
    private void RemovePlayer()
    {

        //rigidbodyのrotationの軸固定を外す
        var rb = this.gameObject.GetComponent<Rigidbody>();
        if(rb != null)
        {

           
            rb.constraints = RigidbodyConstraints.FreezePositionZ
                | RigidbodyConstraints.FreezeRotationX
                | RigidbodyConstraints.FreezeRotationY;
        }

        //ヒットストップ演出
        var timeManager = GameObject.FindWithTag("TimeManager").GetComponent<TimeManager>();
        if(timeManager != null)
        {

            timeManager.StopTime();

        }
        //エフェクトの作成

        var  displayeffect = GameObject.FindWithTag("DisplayEffectManager").GetComponent<DisplayEffectManager>();
        if(displayeffect != null)
        {
            displayeffect.DisplayGemeOverClip();
            

        }
        //カメラの表示するターゲットの変更

        var cameraManager = GameObject.FindWithTag("CameraManager").GetComponent<CameraManager>();
        if(cameraManager != null)
        {


            cameraManager.SelectLookTarget(_characterStatus.CurrentCharacterType);

        }

        //サブキャラクタのアニメを再生
        var subplayeranim = this.gameObject.GetComponent<SubPlayerAnimator>();
        if(subplayeranim!= null)
        {
            subplayeranim.PlayEndeclip();
        }



        //gamemanagerに失敗したことを申請

        var gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        if (gameManager != null)
        {
            gameManager.DefeatPlayer();
        }
        //エフェクト生成
        SetLastEffect();



    }

    /// <summary>
    /// ゲームオーバー時にプレイヤーにエフェクトを発生させる。
    /// </summary>
    private void SetLastEffect()
    {
        //エフェクト作成
        if (_Breakeparticle != null)
        {
            //プレハブ
            GameObject particle = (GameObject)Instantiate(_Breakeparticle, transform.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0));
        }


    }



}

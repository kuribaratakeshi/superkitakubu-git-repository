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
    /// �_���[�W���󂯂����m�F����B
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
    /// �Q�[���I�[�o�[�����ɒB���Ă��邩�m�F����B
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
    /// �v���C���[�Q�[���I�[�o�[����
    /// </summary>
    private void RemovePlayer()
    {

        //rigidbody��rotation�̎��Œ���O��
        var rb = this.gameObject.GetComponent<Rigidbody>();
        if(rb != null)
        {

           
            rb.constraints = RigidbodyConstraints.FreezePositionZ
                | RigidbodyConstraints.FreezeRotationX
                | RigidbodyConstraints.FreezeRotationY;
        }

        //�q�b�g�X�g�b�v���o
        var timeManager = GameObject.FindWithTag("TimeManager").GetComponent<TimeManager>();
        if(timeManager != null)
        {

            timeManager.StopTime();

        }
        //�G�t�F�N�g�̍쐬

        var  displayeffect = GameObject.FindWithTag("DisplayEffectManager").GetComponent<DisplayEffectManager>();
        if(displayeffect != null)
        {
            displayeffect.DisplayGemeOverClip();
            

        }
        //�J�����̕\������^�[�Q�b�g�̕ύX

        var cameraManager = GameObject.FindWithTag("CameraManager").GetComponent<CameraManager>();
        if(cameraManager != null)
        {


            cameraManager.SelectLookTarget(_characterStatus.CurrentCharacterType);

        }

        //�T�u�L�����N�^�̃A�j�����Đ�
        var subplayeranim = this.gameObject.GetComponent<SubPlayerAnimator>();
        if(subplayeranim!= null)
        {
            subplayeranim.PlayEndeclip();
        }



        //gamemanager�Ɏ��s�������Ƃ�\��

        var gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        if (gameManager != null)
        {
            gameManager.DefeatPlayer();
        }
        //�G�t�F�N�g����
        SetLastEffect();



    }

    /// <summary>
    /// �Q�[���I�[�o�[���Ƀv���C���[�ɃG�t�F�N�g�𔭐�������B
    /// </summary>
    private void SetLastEffect()
    {
        //�G�t�F�N�g�쐬
        if (_Breakeparticle != null)
        {
            //�v���n�u
            GameObject particle = (GameObject)Instantiate(_Breakeparticle, transform.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0));
        }


    }



}

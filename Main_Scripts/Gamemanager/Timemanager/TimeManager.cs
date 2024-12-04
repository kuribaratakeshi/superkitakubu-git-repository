using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private bool _isSetTimer = false;
    [SerializeField]
    private bool _isUpTime;
    [SerializeField]
    private float _currenttimer;
    [SerializeField]
    private float _upTime;
    [SerializeField]
    private float _downTime;





    public AnimationCurve timeease = AnimationCurve.EaseInOut(
    timeStart: 0f,
    valueStart: 0f,
    timeEnd: 1f,
    valueEnd: 1f
    );

    // Update is called once per frame

    public void StopTime()
    {
        Startskilloneact();
    }



    /// <summary>
    /// �ŏ��ɍs���鏈���^�C�}�[��������
    /// </summary>
    private void Startskilloneact()
    {
        //�ŏ��̏���
        _isUpTime = true;
        //�^�C�}�[�J�n
        _isSetTimer = true;



        _currenttimer = 0;

    }

    private void AfterEndSkilloneact()
    {

        Time.timeScale = 1.0f;



    }

    void Update()
    {


        if (_isSetTimer == true)
        {
            if (_isUpTime == true)
            {
                _currenttimer += _upTime * Time.deltaTime;
            }
            else
            {
                _currenttimer -= _downTime * Time.deltaTime;
            }


            if (_currenttimer >= 1)
            {
                _currenttimer = 1;

                //_isUpTime = false;
            }


            Time.timeScale = GetValue(_currenttimer);

            if (_currenttimer <= 0)
            {
                _currenttimer = 0;
                _isSetTimer = false;
                AfterEndSkilloneact();
            }
        }



    }


    public float GetValue(float time)
    {
        return timeease.Evaluate(time);
    }



}

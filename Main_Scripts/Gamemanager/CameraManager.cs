using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using static CharacterStatus;
using static Scenemanager;

public class CameraManager : MonoBehaviour
{


    [SerializeField] private CinemachineVirtualCamera _virtulCameraPlayer;
    [SerializeField] private CinemachineVirtualCamera _virtulCameraSubPlayer;


    // 表示しないバーチャルカメラの優先度
    [SerializeField] private int _nolookPriority = 0;

    // 表示するバーチャルカメラの優先度
    [SerializeField] private int _lookPriority = 10;

    private void Start()
    {
        
        _virtulCameraPlayer.Priority = _lookPriority;
        _virtulCameraSubPlayer.Priority = _nolookPriority;

    }


    public void SelectLookTarget(CharacterType　selecttype)
    {

        switch (selecttype)
        {
            case CharacterType.MAIN_PLAYER:
                ChangeLookPlayer();
                break;

            case CharacterType.SUB_PLAYER:
                ChangeLookSubPlayer();
                break;
        }




    }



    private void ChangeLookPlayer()
    {
        _virtulCameraPlayer.Priority = _lookPriority;
        _virtulCameraSubPlayer.Priority = _nolookPriority;

    }
    private void ChangeLookSubPlayer()
    {
        _virtulCameraPlayer.Priority = _nolookPriority;
        _virtulCameraSubPlayer.Priority = _lookPriority;



    }






}

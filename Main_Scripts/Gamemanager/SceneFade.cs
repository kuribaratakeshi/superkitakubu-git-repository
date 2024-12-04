using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour
{

    [SerializeField]
    private Animator _sceneAnimator;
    [SerializeField]
    private AnimationClip _sceneStartclip;
    [SerializeField]
    private AnimationClip _sceneEndclip;




    public void StartScene()
    {
        LoadAnimation(_sceneStartclip);
    }
    public void EndScene()
    {
        LoadAnimation(_sceneEndclip);
    }




    private void LoadAnimation(AnimationClip currentanim)
    {


        _sceneAnimator.CrossFadeInFixedTime(currentanim.name, 0);



    }









}

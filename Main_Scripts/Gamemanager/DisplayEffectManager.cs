using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayEffectManager : MonoBehaviour
{

    [SerializeField]
    private Animator _displayEffectAnimator;
    [SerializeField]
    private AnimationClip _gameOverClip;
    [SerializeField]
    private AnimationClip _returnNormalClip;


    public void DisplayGemeOverClip()
    {
        LoadAnimation(_gameOverClip);
    }

    public void DisplayNormalClip()
    {
        LoadAnimation(_returnNormalClip);
    }




    private void LoadAnimation(AnimationClip currentanim)
    {
        _displayEffectAnimator.CrossFadeInFixedTime(currentanim.name, 0);
    }


}

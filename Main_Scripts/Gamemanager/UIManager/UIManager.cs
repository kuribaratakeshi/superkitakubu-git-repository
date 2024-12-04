using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Animator _UIAnimator;
    [SerializeField]
    private AnimationClip _UIStartClip;
    [SerializeField]
    private AnimationClip _UIDamegeClip;
    [SerializeField]
    private AnimationClip _UIGoalAnimationClip;

    public void StartUIAnim()
    {

        _UIAnimator.Play(_UIStartClip.name);

    }


}

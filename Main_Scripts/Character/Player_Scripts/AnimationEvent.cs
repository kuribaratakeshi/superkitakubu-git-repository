using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{

    [SerializeField]
    private AudioSource _audioSoruce;
    [SerializeField]
    private AudioClip _stepsound;




    public void Step(AnimationEvent animationEvent)
    {


        _audioSoruce.PlayOneShot(_stepsound);
    }

}

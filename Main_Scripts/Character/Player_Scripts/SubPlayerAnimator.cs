using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubPlayerAnimator : MonoBehaviour
{

    [SerializeField]
    private Animator _subPlayerAnimator;
    [SerializeField]
    private AnimationClip _NormalClip;
    [SerializeField]
    private AnimationClip _DamegeClip;
    [SerializeField]
    private AnimationClip _EndClip;
    CharacterStatus _characterstatus;

    private void Start()
    {
        _characterstatus = GetComponent<CharacterStatus>();
        PlayNormalclip();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.GetComponent<CharacterStatus>() != null)
        {
            if (_characterstatus.CurrentIsDeath==false)
            {
                Debug.Log("damege");
                PlayDamegeclip();
            }
            


        }
        

    }

    private void PlayNormalclip()
    {

        _subPlayerAnimator.Play(_NormalClip.name);
    }
    private  void PlayDamegeclip()
    {
        LoadAnimation(_DamegeClip);
    }
    public void PlayEndeclip()
    {
      
        _subPlayerAnimator.Play(_EndClip.name);
    }




    private void LoadAnimation(AnimationClip currentanim)
    {


        _subPlayerAnimator.CrossFadeInFixedTime(currentanim.name, 0);



    }

    


}

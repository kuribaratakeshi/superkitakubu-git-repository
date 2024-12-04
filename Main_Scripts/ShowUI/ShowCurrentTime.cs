using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class ShowCurrentTime : MonoBehaviour
{
    [SerializeField]
    private GameManager gamemanager;

    [SerializeField]
    private Text _scoretext;
    // Update is called once per frame
    void Update()
    {

        if (gamemanager != null)
        {

            if (_scoretext != null)
            {
                

                _scoretext.text = "ƒ^ƒCƒ€:"+gamemanager.CurrentScoreTime.ToString("f2");
            }


        }
    }

}

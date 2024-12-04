using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCharacterStatus : MonoBehaviour
{

    [SerializeField]
    private CharacterStatus _playerStatus;
    [SerializeField]
    private CharacterStatus _subPlayerStatus;
    [SerializeField] 
    private DestoryDistance _distance;

    [SerializeField]
    private Text _playerhptext;
    [SerializeField]
    private Text _subplayerhptext;

    [SerializeField]
    private Text _currentdistancetext;
    // Update is called once per frame
    void Update()
    {

        if (_playerStatus !=null&& _subPlayerStatus !=null)
        {

            if(_playerhptext != null && _subplayerhptext!= null&& _currentdistancetext !=null)
            {
                _playerhptext.text = _playerStatus.CurrentHP.ToString();
                _subplayerhptext.text = _subPlayerStatus.CurrentHP.ToString();
                if((_distance.CurrentDistance/_distance.CurrentDestoryDistance) >= 0.7f)
                {
                    _currentdistancetext.color= Color.red;

                }
                else
                {
                    _currentdistancetext.color = Color.white;
                }

                _currentdistancetext.text = _distance.CurrentDistance.ToString("f2");
            }
          

        }    




    }



}

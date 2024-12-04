using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCalc : MonoBehaviour
{


    private GameObject _goalObj;
    [SerializeField]
    private Text _distancetext;
    private GameObject _subPlayer;
    // Start is called before the first frame update
    void Start()
    {
        _goalObj = GameObject.FindWithTag("Goal");
        _subPlayer = GameObject.FindWithTag("Sub_Player");

    }

    // Update is called once per frame
    void Update()
    {

        
        if (_distancetext != null)
        {
            

            if (_goalObj!= null && _subPlayer != null) {
                

                var distance = Vector3.Distance(_goalObj.transform.position, _subPlayer.transform.position) ;
                _distancetext.text = "‚Ì‚±‚è"+distance.ToString("f2");
            
            
            }



        }



    }



}

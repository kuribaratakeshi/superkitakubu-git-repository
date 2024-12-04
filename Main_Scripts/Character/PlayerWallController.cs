using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerWallController : MonoBehaviour
{

    [SerializeField]
    private float _addSize=1;
    private float _objcontrast = 0;
    [SerializeField]
    private float _currenttimer = 0;

    [SerializeField]
    private float _upTime;
    [SerializeField]
    private float _downTime;

    public AnimationCurve timecurve = AnimationCurve.EaseInOut(
    timeStart: 0f,
    valueStart: 0f,
    timeEnd: 1f,
    valueEnd: 1f
    );
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

     
            if (Input.GetMouseButton(0) == true)
            {
                _currenttimer += _upTime * Time.deltaTime;
               
            }
            else
            {
                _currenttimer -= _downTime * Time.deltaTime;
            }



            if (_currenttimer <= 0)
            {
                _currenttimer = 0;

            }
        ChangeObjScale();


    }


    private void ChangeObjScale()
    {

        if (_currenttimer >= 1)
        {
            _currenttimer = 1;
        }

        _objcontrast = timecurve.Evaluate(_currenttimer);

        var localScale = transform.localScale;
        localScale.z = (1+_objcontrast* _addSize);
        transform.localScale = localScale;
        

    } 

}

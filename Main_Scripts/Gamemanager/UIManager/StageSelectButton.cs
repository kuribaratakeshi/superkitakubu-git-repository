using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageSelectButton : MonoBehaviour
{

    [SerializeField]
    private GameManager _gameManager;

    [SerializeField]
    private Button _stage1Button;
    [SerializeField]
    private Button _stage2Button;
    [SerializeField]
    private Button _stage3Button;
    [SerializeField]
    private Button _stage4Button;

    [SerializeField]
    private bool _hastask = true;

    void Start()
    {
        _stage1Button.onClick.AddListener(SelectStage1);
        _stage2Button.onClick.AddListener(SelectStage2);
        _stage3Button.onClick.AddListener(SelectStage3);
        _stage4Button.onClick.AddListener(SelectStage4);

    }

    private void SelectStage1()
    {
        if (_hastask == true)
        {
            _gameManager.SetStage1();
            Onclik();

        }
      

    }

    private void SelectStage2()
    {
        if (_hastask == true)
        {
            _gameManager.SetStage2();
            Onclik();
        }
  

    }

    private void SelectStage3()
    {
        if (_hastask == true)
        {
            _gameManager.SetStage3();
            Onclik();

        }
 
    }

    private void SelectStage4()
    {
        if (_hastask == true)
        {
            _gameManager.SetStage4();
            Onclik();
        }


    }


    private void Onclik()
    {

        _hastask = false;


    }


}

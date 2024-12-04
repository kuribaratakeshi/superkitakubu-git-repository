using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{

    [SerializeField]
    private UIManager _uiManager;

    [SerializeField]
    private Button _startButton;
    [SerializeField]
    private GameObject _playerObj;
    [SerializeField]
    private GameObject _subPlayerObj;
    [SerializeField]
    private GameManager _gameManager;
    [SerializeField]
    private OnActiveCharacter _onActive;

    private bool _hastask = true;
    // Start is called before the first frame update
    void Start()
    {
        _startButton.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �Q�[�����J�n����
    /// </summary>
    private void StartGame()
    {
        if (_hastask == true)
        {

            //�A�j���[�V�����̍Đ�

            _uiManager.StartUIAnim();

            //�v���C���[�̑��x��������
            IChangeSpeed playerspeed = _playerObj.gameObject.GetComponent<IChangeSpeed>();

            if (playerspeed != null)
            {
                playerspeed.ResetSpeed();
            }
            //�T�u�v���C���[�̑��x��������
            IChangeSpeed subplayerspeed = _subPlayerObj.gameObject.GetComponent<IChangeSpeed>();

            if (subplayerspeed != null)
            {
                subplayerspeed.ResetSpeed();
            }

            //�^�C�}�[�J�n
            _gameManager.StartThisGame();

            //OnActiveCharacter���N��

            _onActive.CurrentCan = true;


            _hastask= false;

        }

    }


}

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
    /// ゲームを開始する
    /// </summary>
    private void StartGame()
    {
        if (_hastask == true)
        {

            //アニメーションの再生

            _uiManager.StartUIAnim();

            //プレイヤーの速度を初期化
            IChangeSpeed playerspeed = _playerObj.gameObject.GetComponent<IChangeSpeed>();

            if (playerspeed != null)
            {
                playerspeed.ResetSpeed();
            }
            //サブプレイヤーの速度を初期化
            IChangeSpeed subplayerspeed = _subPlayerObj.gameObject.GetComponent<IChangeSpeed>();

            if (subplayerspeed != null)
            {
                subplayerspeed.ResetSpeed();
            }

            //タイマー開始
            _gameManager.StartThisGame();

            //OnActiveCharacterを起動

            _onActive.CurrentCan = true;


            _hastask= false;

        }

    }


}

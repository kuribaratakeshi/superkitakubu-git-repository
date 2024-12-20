using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReTryButtom : MonoBehaviour
{
    [SerializeField]
    private GameManager _gamemanager;

    [SerializeField]
    private Button _reTryButton;

    [SerializeField]
    private bool _hastask = true;
    // Start is called before the first frame update
    void Start()
    {
        _gamemanager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        _reTryButton.onClick.AddListener(ReTryThisGame);
    }

    /// <summary>
    /// リプレイの命令を出す
    /// </summary>
    private void ReTryThisGame()
    {
        if (_hastask == true)
        {
            Debug.Log("りとり");
            _gamemanager.QuickRePlay();
            _hastask = false;
        }


    }

}

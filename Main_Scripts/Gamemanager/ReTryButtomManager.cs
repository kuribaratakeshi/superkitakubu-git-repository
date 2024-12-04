using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReTryButtomManager : MonoBehaviour
{

    [SerializeField]
    private GameManager _gamemanager;

    private bool _hastask=true;

    [SerializeField]
    private GameObject _reTryButtom;
    private void Start()
    {
        _gamemanager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        _reTryButtom.SetActive(false);
    }

    private void Update()
    {
        if(_gamemanager.CurrentIsgameEnd == true)
        {

            ShowRetryButtom();

            _hastask =false;
        }

    }

    /// <summary>
    /// リトライボタンを表示する。
    /// </summary>
    private void ShowRetryButtom()
    {

        _reTryButtom.SetActive(true);

    }






}

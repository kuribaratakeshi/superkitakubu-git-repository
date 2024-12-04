using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static CharacterStatus;
/// <summary>
/// さわったらゲームシーンを終了させるコンポーネント
/// </summary>
public class OnFinishEnter : MonoBehaviour
{

    GameManager gameManager;


    private void Awake()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (ISSubPlayer(other) == true)
        {
            FinishGameScene();
        }
    }

    private bool ISSubPlayer(Collider other)
    {
        bool issubplayer = false;

        if (other != null)
        {

            if(other.gameObject.tag== "Sub_Player")
            {

            var status =other.gameObject.GetComponent<CharacterStatus>();
                if (status.CurrentIsDeath == false)
                {
                    issubplayer = true;
                }


                  
            }


        }


        return issubplayer;
    }


    private void FinishGameScene()
    {
        if (gameManager != null)
        {
            gameManager.GoalPlayer();
        }
    }

      



    








}

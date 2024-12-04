using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Scenemanager;

public class ResultSave : MonoBehaviour
{



    private int _goalsum=0;

    private void Start()
    {
        GoalStageCalc();
    }

    public int goalSum()
    {

        GoalStageCalc();



        return _goalsum;   
    }



    /// <summary>
    /// クリアした際に呼び出される
    /// </summary>
    public void SaveStageResul(SceneType goalScene)
    {
        switch (goalScene)
        {

            case SceneType.RACE1:
                PlayerPrefs.SetInt("STAGE1",1);
                break;
            case SceneType.RACE2:
                PlayerPrefs.SetInt("STAGE2", 1);
                break;
            case SceneType.RACE3:
                PlayerPrefs.SetInt("STAGE3", 1);
                break;
            case SceneType.RACE4:
                PlayerPrefs.SetInt("STAGE4", 1);
                break;

               

        }

        PlayerPrefs.Save();
        Debug.Log("are");
        GoalStageCalc();


    }
    /// <summary>
    /// ゴールしたステージの合計を計算する。
    /// </summary>
    private void GoalStageCalc()
    {
        var stage1 = PlayerPrefs.GetInt("STAGE1", 0);
        var stage2 = PlayerPrefs.GetInt("STAGE2", 0);
        var stage3 = PlayerPrefs.GetInt("STAGE3", 0);
        var stage4 = PlayerPrefs.GetInt("STAGE4", 0);
        _goalsum = stage1 + stage2 + stage3 + stage4;
        Debug.Log(_goalsum);



    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using unityroom.Api;
using static Scenemanager;

public class ScoreResult : MonoBehaviour
{

    [SerializeField]
    private  GameManager _manager;
    [SerializeField]
    private ResultSave _resultSave;

    public Text scoretext;
    public Text scenename;
    public Text raceresult;
    public Text goalstagescore;

    private string selectedscenename;
    private void Start()
    {
        SendGoalStage();
        CheckScene(_manager.REPlayScene);
        CheckGoal();
        CheckNumGoalStage();
        


    }

    // Update is called once per frame
    void Update()
    {

        if (scoretext != null)
        {


            scoretext.text = _manager.resultscore.ToString("f2");

        }



    }

    private void CheckGoal()
    {
        if (_manager.IsGoal==true)
        {
            raceresult.text = "�A��I";
        }
        else
        {
            raceresult.text = "�A��s�I";

        }

        

    }
    /// <summary>
    /// �S�[�������X�e�[�W�̐����m�F����B
    /// </summary>
    private void CheckNumGoalStage()
    {

        goalstagescore.text = _resultSave.goalSum().ToString();

        UnityroomApiClient.Instance.SendScore(1, _resultSave.goalSum(), ScoreboardWriteMode.HighScoreDesc);

    }

    /// <summary>
    /// �S�[�������X�e�[�W�𑗂�
    /// </summary>
    private void SendGoalStage()
    {
        if(_manager.IsGoal==true) {
            _resultSave.SaveStageResul(_manager.REPlayScene);
        }
       


    }

    /// <summary>
    /// �v���C�����V�[�����m�F����
    /// </summary>
    /// <param name="selectedScene"></param>
    private void CheckScene(SceneType selectedScene)
    {

        switch (selectedScene)
        {
       
            case SceneType.RACE1:
                selectedscenename = "���[���[";
                break;
            case SceneType.RACE2:
                selectedscenename = "�ӂ�";
                break;
            case SceneType.RACE3:
                selectedscenename = "���傢�ނ�";
                break;
            case SceneType.RACE4:
                selectedscenename = "�߂���ނ�";
                break;



        }

        scenename.text= selectedscenename;
    }

}

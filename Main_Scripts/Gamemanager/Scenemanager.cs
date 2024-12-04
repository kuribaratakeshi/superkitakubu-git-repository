using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static CharacterStatus;

[RequireComponent(typeof(SceneFade))]
public class Scenemanager : MonoBehaviour
{

    [SerializeField]
    private GameManager _gamemanager;
    public enum SceneType
    {
        TITLE,
        RACE1,
        RACE2,
        RACE3,
        RACE4,
        RESULT

    }

    [SerializeField]
    private SceneType _selectNextScene;
    public SceneType CurrentSelectNextScene
    {
        get { return _selectNextScene; }
        set { _selectNextScene = value; }

    }

    //
    private SceneType _rePlayScene;


    [SerializeField] private float _swaittime = 3f;

    [SerializeField] SceneFade _scenefade;

    private void Start()
    {
        _gamemanager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }
    public void OpenSceneWindow()
    {


        _scenefade = GetComponent<SceneFade>();

        _scenefade.StartScene();

    }

    /// <summary>
    /// 次のシーンを決定する。
    /// </summary>
    public void SetNextScene(SceneType nextScene)
    {
        CurrentSelectNextScene = nextScene ;
        _scenefade.EndScene();
        //コルーチンの起動
        StartCoroutine(DelayCoroutine());

    }
       
    public void QuickNextScene(SceneType nextScene)
    {
        CurrentSelectNextScene = nextScene;
        _scenefade.EndScene();
        LoadNextScene();
    }
    

    /// <summary>
    /// シーンの切り替え前に呼び出すメソッドを登録する。(一番最初に呼び出される。)
    /// </summary>
    public void LoadNextScene()
    {
        SceneManager.sceneLoaded += LoadNextScene;

        SceneManager.LoadScene(SetSceneName());


    }
    /// <summary>
    /// 待機時間後につぎのシーンに移行する
    /// </summary>
    /// <returns></returns>
    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(_swaittime);
        LoadNextScene();



    }

        private string SetSceneName()
    {
        var NextSceneName = "";

        switch (_selectNextScene)
        {
            case SceneType.TITLE:
                NextSceneName = "title";
                break;
            case SceneType.RACE1:
                NextSceneName = "TestStage 1";
                break;
            case SceneType.RACE2:
                NextSceneName = "TestStage 2";
                break;
            case SceneType.RACE3:
                NextSceneName = "TestStage 3";
                break;
            case SceneType.RACE4:
                NextSceneName = "TestStage 4";
                break;
            case SceneType.RESULT:
                NextSceneName = "ResultScene";
                break;


        }

        return NextSceneName;
    }
    /// <summary>
    ///　シーン切り替え時に呼ばれ次のシーンのスクリプトを取得し変数を渡す。
    /// </summary>
    private void LoadNextScene(Scene next, LoadSceneMode mode)
    {

        var gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        
        gameManager.SetScore(_gamemanager.CurrentScoreTime);

        gameManager.SetCurrentScene(CurrentSelectNextScene);

        gameManager.SetRePlayScene(_gamemanager.CurrentPlayScene);
        
        //リザルト画面にステージが完走結果を送る
        if (CurrentSelectNextScene == SceneType.RESULT)
        {

            gameManager.SendResul(_gamemanager.IsGoal);

        }



        // イベントから削除
        SceneManager.sceneLoaded -= LoadNextScene;

    }










}

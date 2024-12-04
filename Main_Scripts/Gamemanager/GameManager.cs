using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Scenemanager;
using static UnityEngine.ParticleSystem;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private SceneType _selectNextScene;


    [SerializeField]
    private GameObject _ScenePrefab;

 
    private Scenemanager _sceneManager;

    private float _scoreTime=0f;

    public float resultscore;

    private bool _Isgoal = false;

    public bool IsGoal
    {
        get { return _Isgoal; }
        set { _Isgoal = value; }
    }

    public float CurrentScoreTime
    {

        get { return _scoreTime; }
        set { _scoreTime = value; }

    }
    [SerializeField]
    private SceneType _currentPlayScene;


    public SceneType CurrentPlayScene
    {
        get { return _currentPlayScene; }
        set { _currentPlayScene = value; }
    }

    [SerializeField]
    private SceneType _rePlayScene;
    public SceneType REPlayScene
    {
        get { return _rePlayScene; }
        set { _rePlayScene = value; }
    }


    [SerializeField]
    private bool _isgameplay=false;

    [SerializeField]
    private bool _isgameEnd = false;

    public bool CurrentIsgameEnd
    {

        get { return _isgameEnd; }
        set { _isgameEnd = value; }

    }


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
     
        StartThisScene();
    }


    private void Update()
    {
        if(_isgameplay)
        {

            _scoreTime += Time.deltaTime;



        }
        else
        {




        }



    }


    /// <summary>
    /// �V�[�����J�n����B
    /// </summary>
    private void StartThisScene()
    {
        //�V�[���}�l�[�W���[���Z�b�g����B
        var sceneprefab = (GameObject)Instantiate(_ScenePrefab, transform.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0));
        _sceneManager = sceneprefab.GetComponent<Scenemanager>();

        _sceneManager.OpenSceneWindow();



    }

    /// <summary>
    /// �Q�[�����J�n����
    /// </summary>
    public void StartThisGame()
    {

        _isgameplay = true;

    }
    
    
    public void GoalPlayer()
    {
       
       IsGoal =true;
       FinishThisGame();
    }
    public void DefeatPlayer()
    {
       CurrentIsgameEnd = true;
       IsGoal = false;
       FinishThisGame();
    }


    /// <summary>
    /// �V�[�����I������B
    /// </summary>
    private void FinishThisGame()
    {
        _isgameplay=false;
        _sceneManager.SetNextScene(_selectNextScene);


    }
    /// <summary>
    /// �V�[������蒼��
    /// </summary>
    public void RePlayScene()
    {
         _isgameplay=false;
        _sceneManager.SetNextScene(_rePlayScene);


    }

    /// <summary>
    /// ���݂̃V�[������蒼��
    /// </summary>
    public void QuickRePlay()
    {
        _isgameplay = false;
        _sceneManager.QuickNextScene(CurrentPlayScene);


    }






    /// <summary>
    /// ���݂̃V�[����ݒ肷��
    /// </summary>
    /// <param name="currentScene"></param>
    public void SetCurrentScene(SceneType currentScene)
    {

        _currentPlayScene = currentScene;
    }



    /// <summary>
    /// ���v���C�p��enum��ݒ肷��
    /// </summary>
    /// <param name="ReStartScene"></param>

    public void SetRePlayScene(SceneType ReStartScene)
    {

        _rePlayScene = ReStartScene ;

    }

    public void SetScore(float score)
    {

        resultscore = score;

    }

    /// <summary>
    /// ���U���g�V�[��������΂��
    /// </summary>
    /// <param name="result"></param>
    public void SendResul(bool result)
    {
        IsGoal = result;


    }

    public void SetStage1()
    {
        _selectNextScene = SceneType.RACE1;
        FinishThisGame();
    }
    public void SetStage2()
    {
        _selectNextScene = SceneType.RACE2;
        FinishThisGame();
    }
    public void SetStage3()
    {
        _selectNextScene = SceneType.RACE3;
        FinishThisGame();
    }
    public void SetStage4()
    {
        _selectNextScene = SceneType.RACE4;
        FinishThisGame();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(Rigidbody))]
public abstract class MovementBase : MonoBehaviour, IChangeSpeed
{
    [SerializeField]
    protected float _moveSpeedBase = 10f;
    [SerializeField]
    protected float _moveSpeed = 10f;
    [SerializeField]
    protected float _firstSpeed = 10f;

    protected Rigidbody rb;

    protected Vector3 moveDirection;

    /// <summary>
    /// 移動速度の変更処理
    /// </summary>
    /// <param name="value"></param>


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        FirstMove();

    }

    protected virtual void FirstMove()
    {

    }
    public void ChangeSpeed(float value)
    {

        _moveSpeed = value;

    }

    /// <summary>
    /// 移動速度の初期化
    /// </summary>

    public void ResetSpeed()
    {
        Debug.Log(this.gameObject+"bass"+_moveSpeedBase);
        _moveSpeed = _moveSpeedBase;
        Debug.Log(this.gameObject+"move" +_moveSpeed);
    }

 

    void Update()
    {
        CheckStatus();
        SpeedControl();
    }

    protected virtual void CheckStatus()
    {


    }
    void FixedUpdate()
    {
        Move();
    }


    /// <summary>
    /// 速度制限
    /// </summary>

    protected virtual void SpeedControl()
    {

    }

    /// <summary>
    /// プレイヤーの移動処理
    /// </summary>

    protected virtual void Move()
    {

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class PlayerMove : MovementBase
{


    [SerializeField]
    protected float _delaymoveSpeed = 5f;
    [SerializeField]
    protected bool _isDelay=false;

    Vector2 moveInput;

    protected override void FirstMove()
    {

    
    }

    void Update()
    {
        if (Input.GetMouseButton(1) == true)
        {

            _isDelay = true;
        }
        else
        {
            _isDelay = false;
        }

        SpeedControl();

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(x, y);
        moveInput.Normalize();//斜めの距離が長くなるのを防ぐ

    }

    void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// 速度制限
    /// </summary>
    protected override void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f,rb.velocity.z);

        if (_isDelay == false)
        {

            if (flatVel.magnitude > _moveSpeed)
            {
                Vector3 limitdVel = flatVel.normalized * _moveSpeed;

                rb.velocity = new Vector3(limitdVel.x, rb.velocity.y, limitdVel.z);

            }
        }
        if (_isDelay == true)
        {
            if (flatVel.magnitude > _delaymoveSpeed)
            {
                Vector3 limitdVel = flatVel.normalized * _delaymoveSpeed;

                rb.velocity = new Vector3(limitdVel.x, rb.velocity.y, limitdVel.z);

            }


        }




    }

    /// <summary>
    /// プレイヤーの移動処理
    /// </summary>
    protected override void Move()
    {
        //進行方向
        moveDirection = this.transform.forward * moveInput.y + this.transform.right * moveInput.x;


       //進行方向に設定速度を乗じた力を与える。
        rb.AddForce(moveDirection.normalized * _moveSpeed * _firstSpeed, ForceMode.Force);
    }






}

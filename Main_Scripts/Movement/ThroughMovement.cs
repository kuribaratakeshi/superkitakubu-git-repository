using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;




public class ThroughMovement : MovementBase
{

    //rightがfalse、leftがtrue
    [SerializeField]
    private bool _isDirection=false;
    //rightがfalse、leftがtrue
    [SerializeField]
    private bool _canMove = false;


    protected override void FirstMove()
    {
        _canMove= true;
    }


    /// <summary>
    /// 速度制限
    /// </summary>

    protected override void SpeedControl()
    {

        if (_canMove == true)
        {

            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            if (flatVel.magnitude > _moveSpeed)
            {
                Vector3 limitdVel = flatVel.normalized * _moveSpeed;

                rb.velocity = new Vector3(limitdVel.x, rb.velocity.y, limitdVel.z);

            }
        }
     
    }

    /// <summary>
    /// プレイヤーの移動処理
    /// </summary>

    protected override void Move()
    {
        if (_canMove==true) {
            //進行方向
            if (_isDirection)
            {
                moveDirection = Vector3.left;
            }
            else
            {
                moveDirection = Vector3.right;
            }



            //進行方向に設定速度を乗じた力を与える。
            rb.AddForce(moveDirection.normalized * _moveSpeed * _firstSpeed, ForceMode.Force);
        }
      
    }

    public void SetCanNotMove()
    {
        _canMove= false;
    }


}

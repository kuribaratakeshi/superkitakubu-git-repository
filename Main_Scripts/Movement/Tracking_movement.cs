using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStatus))]

public class Tracking_movement : MovementBase
{

    [SerializeField] private CharacterStatus _characterStatus;


    [SerializeField]private GameObject lookTarget;

    [SerializeField]private float _rotationSpeed =0.1f;

    private bool _canmove=false;
    


    protected override void FirstMove()
    {


        _characterStatus = this.gameObject.GetComponent<CharacterStatus>();


    }
    /// <summary>
    /// 毎フレーム自分の状態を確認する。
    /// </summary>
    protected override void CheckStatus()
    {

        if (lookTarget != null)
        {
            if (_characterStatus.CurrentIsDeath != true)
            {
                _canmove = true;
            }
            else
            {

                _canmove = false;
            }

        }

    }

    /// <summary>
    /// 速度制限
    /// </summary>

    protected override void SpeedControl()
    {
        if (lookTarget != null)
        {
            if (_canmove)
            {
                Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

                if (flatVel.magnitude > _moveSpeed)
                {
                    Vector3 limitdVel = flatVel.normalized * _moveSpeed;
                    rb.velocity = new Vector3(limitdVel.x, rb.velocity.y, limitdVel.z);

                }
            }

        }



    }


    /// <summary>
    /// プレイヤーの移動処理
    /// </summary>

    protected override void Move()
    {
        if (lookTarget != null)
        {
            if (_canmove)
            {
                Rotate();
                //進行方向に設定速度を乗じた力を与える。
                rb.AddForce(transform.forward * _moveSpeed * _firstSpeed, ForceMode.Force);
            }
        }


    }

    /// <summary>
    /// 回転処理
    /// </summary>

    protected void Rotate()
    {
        if (lookTarget != null)
        {
            if (_canmove)
            {
                var direction = lookTarget.transform.position - transform.position;
                direction.y = 0;
                var lookRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, _rotationSpeed);

            }

        }
    }


}

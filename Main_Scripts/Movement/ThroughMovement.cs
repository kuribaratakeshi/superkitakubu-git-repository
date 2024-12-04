using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;




public class ThroughMovement : MovementBase
{

    //right��false�Aleft��true
    [SerializeField]
    private bool _isDirection=false;
    //right��false�Aleft��true
    [SerializeField]
    private bool _canMove = false;


    protected override void FirstMove()
    {
        _canMove= true;
    }


    /// <summary>
    /// ���x����
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
    /// �v���C���[�̈ړ�����
    /// </summary>

    protected override void Move()
    {
        if (_canMove==true) {
            //�i�s����
            if (_isDirection)
            {
                moveDirection = Vector3.left;
            }
            else
            {
                moveDirection = Vector3.right;
            }



            //�i�s�����ɐݒ葬�x���悶���͂�^����B
            rb.AddForce(moveDirection.normalized * _moveSpeed * _firstSpeed, ForceMode.Force);
        }
      
    }

    public void SetCanNotMove()
    {
        _canMove= false;
    }


}
